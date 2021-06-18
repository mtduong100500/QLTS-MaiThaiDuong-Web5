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
    public class AssetTypeRepository : BaseRepository<AssetType>, IAssetTypeRepository
    {
        protected string className = string.Empty;

        #region Fields
        protected IDbConnection DbConnection;
        #endregion

        #region Constructor
        public AssetTypeRepository(IConfiguration configuration) : base(configuration)
        {
            DbConnection = new MySqlConnection(configuration.GetConnectionString("QLTS"));
        }
        #endregion
    }
}
