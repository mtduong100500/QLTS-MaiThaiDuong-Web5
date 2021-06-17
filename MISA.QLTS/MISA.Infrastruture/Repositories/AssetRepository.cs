using Dapper;
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

        #endregion
        #region Methods
        public bool CheckAssetCodeExist(string assetCode)
        {
            var sqlCommand = "call Proc_DuplicateAsset(@assetCode)";
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
