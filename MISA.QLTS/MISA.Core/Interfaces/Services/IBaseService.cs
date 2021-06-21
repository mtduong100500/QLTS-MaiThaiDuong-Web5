using MISA.Core.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Services
{
    public interface IBaseService<MISAEntity>
    {
        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="entity">Đối tượng thêm mới</param>
        /// <returns>Số dòng ảnh hưởng</returns>
        /// CreatedBy: MTDUONG(16/06/2021)s
        ActionServiceResult Insert(MISAEntity entity);

        /// <summary>
        /// Sửa
        /// </summary>
        /// <param name="entity">Đối tượng chỉnh sửa</param>
        /// <returns>Số dòng ảnh hưởng</returns>
        /// CreatedBy: MTDUONG(16/06/2021)
        ActionServiceResult Update(MISAEntity entity, Guid entityId);
        /// <summary>
        /// Xóa
        /// </summary>
        /// <param name="entity">Đối tượng cần xóa</param>
        /// <returns>Số dòng ảnh hưởng</returns>
        /// CreatedBy MTDUONG (16/06/2021)
        ActionServiceResult Delete(Guid entityId);
        
    }
}
