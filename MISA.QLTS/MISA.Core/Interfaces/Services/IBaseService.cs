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
        /// <returns>Số bản ghi thêm mới thành công</returns>
        /// CreatedBy: MTDUONG(16/06/2021)
        int? Insert(MISAEntity entity);

        /// <summary>
        /// Sửa
        /// </summary>
        /// <param name="entity">Đối tượng chỉnh sửa</param>
        /// <returns>Bản ghi sửa thành công</returns>
        /// CreatedBy: MTDUONG(16/06/2021)
        int? Update(MISAEntity entity, Guid entityId);
        /// <summary>
        /// Xóa
        /// </summary>
        /// <param name="entity">Đối tượng cần xóa</param>
        /// <returns>Xóa bản ghi thành công</returns>
        /// CreatedBy MTDUONG (16/06/2021)
        int? Delete(Guid entityId);
        
    }
}
