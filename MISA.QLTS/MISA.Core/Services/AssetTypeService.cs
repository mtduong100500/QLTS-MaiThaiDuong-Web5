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
    public class AssetTypeService : BaseService<AssetType>, IAssetTypeService
    {
        IAssetTypeRepository _assetTypeRepository;
        public AssetTypeService(IAssetTypeRepository assetTypeRepository) : base(assetTypeRepository)
        {
            _assetTypeRepository = assetTypeRepository;
        }

    }
}
