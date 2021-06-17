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

        protected override bool ValidateCustom(Asset entity)
        {
            var isValid = true;
            // Check mã tài sản đã có hay chưa 
            if (string.IsNullOrEmpty(entity.AssetCode))
            {
                return false;
            }
            return true;
        }
    }
}
