using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.Core.Interfaces.Infrastructures;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Infrastruture.Repositories
{
    public class BaseRepository<MISAEntity> : IBaseRepository<MISAEntity>
    {
        #region Fields
        protected IDbConnection DbConnection;
        protected string className = string.Empty;
        #endregion

        #region Constructor
        public BaseRepository(IConfiguration configuration)
        {

            DbConnection = new MySqlConnection(configuration.GetConnectionString("QLTS"));
            className = typeof(MISAEntity).Name;
        }
        #endregion


        #region Methods
        public List<MISAEntity> getAll()
        {
            var sqlCommand = $"Proc_Get{className}";
            var entities = DbConnection.Query<MISAEntity>(sqlCommand, commandType: CommandType.StoredProcedure).ToList();
            return entities;
        }

        public MISAEntity GetById(Guid entityId)
        {
            var sqlCommand = $"SELECT * FROM {className} WHERE {className}Id = @{className}Id";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@{className}Id", entityId);

            var entities = DbConnection.QueryFirstOrDefault<MISAEntity>(sqlCommand, param: dynamicParameters);
            return entities;
        }

        public int Insert(MISAEntity entity)
        {
            var sqlCommandField = "";
            var sqlCommandValue = "";
            var properties = entity.GetType().GetProperties();
            DynamicParameters dynamicParameters = new DynamicParameters();
            int i = 0;
            foreach (var pro in properties)
            {
                i++;
                    var propName = pro.Name;
                    if (i == properties.Length)
                    {
                        sqlCommandField += $"{propName}";
                        sqlCommandValue += $"@{propName}";
                    }
                    else
                    {
                        sqlCommandField += $"{propName},";
                        sqlCommandValue += $"@{propName},";
                    }
            }
            var sqlCommand = $"insert into {className} ({sqlCommandField}) values ({sqlCommandValue})";
            foreach (var pro in properties)
            {
                var propName = pro.Name;
                var propValue = pro.GetValue(entity);
                if (propName == $"{className}Id")
                {
                    propValue = Guid.NewGuid().ToString();
                }
                dynamicParameters.Add($"@{propName}", propValue);
            }
            var res = DbConnection.Execute(sqlCommand, param: dynamicParameters);
            return res;
        }

        /// <summary>
        /// Sửa 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public int Update(MISAEntity entity, Guid entityId)
        {
            var sqlCommandValue = "";
            var condition = "";
            var properties = entity.GetType().GetProperties();
            // Khởi tạo câu lệnh truy vấn
            var sqlCommand = $"UPDATE {className} SET {sqlCommandValue} WHERE {condition}";
            DynamicParameters dynamicParameters = new DynamicParameters();

            var i = 0;
            foreach (var prop in properties)
            {
                var propName = prop.Name;
                var propValue = prop.GetValue(entity);
                if (i == 0)
                {
                    condition = $"{propName} = @{propName}";
                }
                else if (i == properties.Length - 1)
                {
                    sqlCommandValue += $"{propName} = @{propName}";
                }
                else
                {
                    sqlCommandValue += $"{propName} = @{propName},";
                }
                i++;

            }
            foreach (var prop in properties)
            {
                var propName = prop.Name;
                var propValue = prop.GetValue(entity);
                dynamicParameters.Add($"@{propName}", propValue);
            }

            var res = DbConnection.Execute(sqlCommand, param: dynamicParameters);
            return res;

        }

        public int Delete(Guid entityId)
        {
            var sqlCommand = $"DELETE FROM {className} WHERE {className}Id = @{className}Id";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@{className}Id", entityId);
            var res = DbConnection.Execute(sqlCommand, param: dynamicParameters);

            // Trả về kết quả
            return res;
        }
        #endregion
    }
}
