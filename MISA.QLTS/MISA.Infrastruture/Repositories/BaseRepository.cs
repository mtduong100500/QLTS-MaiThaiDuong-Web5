using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.Core;
using MISA.Core.Entitites;
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
        /// <summary>
        /// Khai báo
        /// CreatedBy MTDUONG (17/06/2021)
        /// </summary>
        #region Fields
        protected IDbConnection DbConnection;
        protected string className = string.Empty;
        #endregion

        /// <summary>
        /// Hàm tạo
        /// CreatedBy MTDUONG (17/06/2021)
        /// </summary>
        /// <param name="configuration"></param>
        #region Constructor
        public BaseRepository(IConfiguration configuration)
        {

            DbConnection = new MySqlConnection(configuration.GetConnectionString("QLTS"));
            className = typeof(MISAEntity).Name;
        }
        #endregion


        #region Methods
        /// <summary>
        /// Lấy tất cả dữ liệu
        ///  CreatedBy MTDUONG (17/06/2021)
        /// </summary>
        /// <returns>Danh sách tất cả các bản ghi</returns>
        public List<MISAEntity> getAll()
        {
            var sqlCommand = $"Proc_Get{className}";
            var entities = DbConnection.Query<MISAEntity>(sqlCommand, commandType: CommandType.StoredProcedure).ToList();
            return entities;
        }

        /// <summary>
        /// Lây dữ liệu theo ID
        /// CreatedBy MTDUONG (17/06/2021)
        /// </summary>
        /// <param name="entityId">Id của đối tượng</param>
        /// <returns>Bản ghi cần tìm theo ID</returns>

        public MISAEntity GetById(Guid entityId)
        {
            var sqlCommand = $"SELECT * FROM {className} WHERE {className}Id = @{className}Id";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@{className}Id", entityId);

            var entities = DbConnection.QueryFirstOrDefault<MISAEntity>(sqlCommand, param: dynamicParameters);
            return entities;
        }

        /// <summary>
        /// Thêm dữ liệu
        /// CreatedBy MTDUONG (17/06/2021)
        /// </summary>
        /// <param name="entity">Đối tượng cần thêm</param>
        /// <returns>0: thêm thất bại, 1: thêm thành công</returns>
        public ActionServiceResult Insert(MISAEntity entity)
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
            // Câu truy vấn
            var sqlCommand = $"Proc_Insert{className}";
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
            var res = DbConnection.Execute(sqlCommand, param: dynamicParameters, commandType: CommandType.StoredProcedure);
            return new ActionServiceResult()
            {
                Success = true,
                MISAcode = Enumeration.MISAcode.Success,
                Message = Core.Resources.Resource.SuccessAdd,
                Data = res
            };
        }

        /// <summary>
        /// Sửa dữ liệu
        /// CreatedBy MTDUONG (17/06/2021)
        /// </summary>
        /// <param name="entity">Đối tượng cần sửa</param>
        /// <param name="entityId">Id của đối tượng cần sửa</param>
        /// <returns>0: sửa thất bại, 1: sửa thành công</returns>
        public ActionServiceResult Update(MISAEntity entity, Guid entityId)
        {
            var properties = entity.GetType().GetProperties();
            // Khởi tạo câu lệnh truy vấn

            var sqlCommand = $"Proc_Update{className}";
            DynamicParameters dynamicParameters = new DynamicParameters();

            foreach (var prop in properties)
            {
                var propName = prop.Name;
                var propValue = prop.GetValue(entity);
                if(propName == $"{className}Id")
                {
                    propValue = entityId;
                }
                dynamicParameters.Add($"@{propName}", propValue);
            }
            
            var res = DbConnection.Execute(sqlCommand, param: dynamicParameters, commandType: CommandType.StoredProcedure);
            return new ActionServiceResult()
            {
                Success = true,
                MISAcode = Enumeration.MISAcode.Success,
                Message = MISA.Core.Resources.Resource.SuccessEdit,
                Data = res
            };
        }


        /// <summary>
        /// Xóa dữ liệu
        /// CreatedBy MTDUONG (17/06/2021)
        /// </summary>
        /// <param name="entityId">Id của đối tượng</param>
        /// <returns>0: Xóa thất bại, 1: Xóa thành công</returns>
        public ActionServiceResult Delete(Guid entityId)
        {
            // Câu lệnh truy vấn
            var sqlCommand = $"Proc_Delete{className}";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@{className}Id", entityId);
            var res = DbConnection.Execute(sqlCommand, param: dynamicParameters, commandType: CommandType.StoredProcedure);

            // Trả về kết quả
            return new ActionServiceResult()
            {
                Success = true,
                MISAcode = Enumeration.MISAcode.Success,
                Message = MISA.Core.Resources.Resource.SuccessDelete,
                Data = res
            };
        }
        /// <summary>
        /// Kiểm tra trùng mã tài sản
        /// </summary>
        /// <param name="assetCode">mã tài sản</param>
        /// <returns>True: nếu trùng, False: không trùng</returns>
        public bool CheckCodeExist(string assetCode)
        {
            string sqlcommand = $"Proc_CheckCodeExist";
            DynamicParameters param = new DynamicParameters();
            param.Add("@AssetCode", assetCode);
            var res = DbConnection.QueryFirstOrDefault<bool>(sqlcommand, param: param, commandType: CommandType.StoredProcedure);
            return res;
        }
        #endregion
    }
}
