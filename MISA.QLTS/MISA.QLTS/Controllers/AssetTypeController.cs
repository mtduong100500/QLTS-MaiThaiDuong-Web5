using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entitites;
using MISA.Core.Interfaces.Infrastructures;
using MISA.Core.Interfaces.Services;
using MISA.QLTS.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Infrastruture.Repositories
{
    /// <summary>
    /// Loại tài sản API
    /// CreatedBy MTDUONG (17/06/2021)
    /// </summary>
    public class AssetTypeController : MISAEntityController<AssetType>
    {
        IAssetTypeRepository _assetTypeRepository;
        IAssetTypeService _assetTypeService;

        public AssetTypeController(IAssetTypeService assetTypeService, IAssetTypeRepository assetTypeRepository) : base(assetTypeService, assetTypeRepository)
        {
            _assetTypeService = assetTypeService;
            _assetTypeRepository = assetTypeRepository;
        }
    }
}
