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
        /// <summary>
        /// Hàm khởi tại
        /// CreatedBy MTDUONG (17/06/2021)
        /// </summary>
        /// <param name="baseService"></param>
        /// <param name="baseRepository"></param>
        #region Constructor
        public MISAEntityController(IBaseService<MISAEntity> baseService, IBaseRepository<MISAEntity> baseRepository)
        {
            _baseRepository = baseRepository;
            _baseService = baseService;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Lấy tất cả dữ liệu
        /// CreatedBy MTDUONG (17/06/2021)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var entity = _baseRepository.getAll();
            return Ok(entity);
        }

        /// <summary>
        /// Lấy dữ liệu theo Id
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        [HttpGet("{entityId}")]
        public IActionResult Get(Guid entityId)
        {
            var entity = _baseRepository.GetById(entityId);
            return Ok(entity);
        }

        /// <summary>
        /// Thêm dữ liệu
        /// CreatedBy MTDUONG (17/06/2021)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Sửa dữ liệu
        /// CreatedBy MTDUONG (17/06/2021)
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="entityId"></param>
        /// <returns></returns>
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


        /// <summary>
        /// Xóa dữ liệu
        /// CreatedBy MTDUONG (17/06/2021)
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        [HttpDelete("{entityId}")]
        public IActionResult Delete(Guid entityId)
        {
            var res = _baseService.Delete(entityId);
            return Ok(res);
        }
        #endregion

    }
}
