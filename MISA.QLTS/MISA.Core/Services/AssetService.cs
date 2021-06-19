using MISA.Core.Entitites;
using MISA.Core.Interfaces.Infrastructures;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Services
{
    public class AssetService : BaseService<Asset>, IAssetService
    {
        IAssetRepository _assetRepository;
        public AssetService(IAssetRepository assetRepository) : base(assetRepository)
        {
            _assetRepository = assetRepository;
        }
    }
}
