using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces.Infrastructures
{
    public interface IBaseRepository<MISAEntity>
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>Danh sách tài sản</returns>
        /// CreatedBy mtduong(16/06/2021)
        List<MISAEntity> getAll();

        /// <summary>
        /// Lấy dữ liệu
        /// </summary>
        /// <returns>Thông tin tài sản theo ID</returns>
        /// CreatedBy mtduong(16/06/2021)
        MISAEntity GetById(Guid entityId);

        /// <summary>
        /// Thêm dữ liệu
        /// </summary>
        /// <returns>Thêm thông tin tài sản vào database</returns>
        /// CreatedBy mtduong(16/06/2021)
        int Insert(MISAEntity entity);

        /// <summary>
        /// Sửa dữ liệu
        /// </summary>
        /// <returns>Sửa thông tin tài sản</returns>
        /// CreatedBy mtduong(16/06/2021)
        int Update(MISAEntity entity, Guid EntityId);

        /// <summary>
        /// Xóa dữ liệu
        /// </summary>
        /// <returns>Xóa thông tin tài sản</returns>
        /// CreatedBy mtduong(16/06/2021)
        int Delete(Guid entityId);
    }
}
