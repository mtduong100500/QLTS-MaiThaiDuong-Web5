using Microsoft.Extensions.Configuration;
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
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        /// <summary>
        /// Khai báo
        /// CreatedBy MTDUONG (17/06/2021)
        /// </summary>
        protected string className = string.Empty;

        #region Fields
        protected IDbConnection DbConnection;
        #endregion

        /// <summary>
        /// Hàm tạo
        /// CreatedBy MTDUONG (17/06/2021)
        /// </summary>
        /// <param name="configuration"></param>
        #region Constructor
        public DepartmentRepository(IConfiguration configuration) : base(configuration)
        {
            DbConnection = new MySqlConnection(configuration.GetConnectionString("QLTS"));
        }
        #endregion
    }
}
