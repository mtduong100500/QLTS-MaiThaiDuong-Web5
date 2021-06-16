using Dapper;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySqlConnector;
using Microsoft.Extensions.Configuration;

namespace MISA.Infrastruture.Repositories
{
    public class AssetRepository : BaseRepository<Asset>, IAssetRepository
    {
        protected string className = string.Empty;

        #region Fields
        protected IDbConnection DbConnection;
        #endregion

        #region Constructor
        public AssetRepository(IConfiguration configuration) : base(configuration)
        {

            DbConnection = new MySqlConnection(configuration.GetConnectionString("QLTS"));
        }
        public bool CheckAssetCodeExist(string assetCode)
        {
            var sqlCommand = "SELECT AssetCode FROM Asset WHERE assetCode = @AssetCode";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@AssetCode", assetCode);
            var customerCodeExist = DbConnection.QueryFirstOrDefault<string>(sqlCommand, param: dynamicParameters);
            if (customerCodeExist == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

    }
}
