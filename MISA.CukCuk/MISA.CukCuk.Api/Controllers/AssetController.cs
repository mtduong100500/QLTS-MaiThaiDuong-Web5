﻿using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Infrastructures;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/assets")]
    public class AssetController : MISAEntityController<Asset>
    {

        IAssetRepository _assetRepository;
        IAssetService _assetService;

        public AssetController(IAssetService assetService, IAssetRepository assetRepository) : base(assetService, assetRepository)
        {
            _assetService = assetService;
            _assetRepository = assetRepository;
        }

    }
}
