using Microsoft.AspNetCore.Mvc;
using MISA.Core.Interfaces.Infrastructures;
using MISA.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.QLTS.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class MISAEntityController<MISAEntity> : ControllerBase
    {

        #region Declare
        IBaseService<MISAEntity> _baseService;
        IBaseRepository<MISAEntity> _baseRepository;
        #endregion

        #region Constructor
        public MISAEntityController(IBaseService<MISAEntity> baseService, IBaseRepository<MISAEntity> baseRepository)
        {
            _baseRepository = baseRepository;
            _baseService = baseService;
        }
        #endregion

        #region Methods
        [HttpGet]
        public IActionResult Get()
        {
            var entity = _baseRepository.getAll();
            return Ok(entity);
        }

        [HttpGet("{entityId}")]

        public IActionResult Get(Guid entityId)
        {
            var entity = _baseRepository.GetById(entityId);
            return Ok(entity);
        }

        [HttpPost]
        public IActionResult Post(MISAEntity entity)
        {
            var res = _baseService.Insert(entity);
            if (res == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(res);
            }
        }


        [HttpPut("{entityId}")]
        public IActionResult Put(MISAEntity entity, Guid entityId)
        {
            var res = _baseService.Update(entity, entityId);
            if (res == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(res);
            }
        }

        [HttpDelete("{entityId}")]
        public IActionResult Delete(Guid entityId)
        {
            var res = _baseService.Delete(entityId);
            return Ok(res);
        }
        #endregion

    }
}
