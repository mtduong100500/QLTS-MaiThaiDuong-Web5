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
        /// <returns>0: Thêm thất bại, 1: Thêm thành công</returns>
        /// CreatedBy: MTDUONG(16/06/2021)s
        int? Insert(MISAEntity entity);

        /// <summary>
        /// Sửa
        /// </summary>
        /// <param name="entity">Đối tượng chỉnh sửa</param>
        /// <returns>0: Sửa thất bại, 1: Sửa thành công</returns>
        /// CreatedBy: MTDUONG(16/06/2021)
        int? Update(MISAEntity entity, Guid entityId);
        /// <summary>
        /// Xóa
        /// </summary>
        /// <param name="entity">Đối tượng cần xóa</param>
        /// <returns>0: Xóa thất bại, 1: Xóa thành công</returns>
        /// CreatedBy MTDUONG (16/06/2021)
        int? Delete(Guid entityId);
        
    }
}
