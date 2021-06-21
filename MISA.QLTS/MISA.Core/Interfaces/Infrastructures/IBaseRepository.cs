using MISA.Core.Entitites;
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
        /// <returns>Dòng ảnh hưởng</returns>
        /// CreatedBy mtduong(16/06/2021)
        ActionServiceResult Insert(MISAEntity entity);

        /// <summary>
        /// Sửa dữ liệu
        /// </summary>
        /// <returns>Dòng ảnh hưởng</returns>
        /// CreatedBy mtduong(16/06/2021)
        ActionServiceResult Update(MISAEntity entity, Guid EntityId);

        /// <summary>
        /// Xóa dữ liệu
        /// </summary>
        /// <returns>Dòng ảnh hưởng</returns>
        /// CreatedBy mtduong(16/06/2021)
        ActionServiceResult Delete(Guid entityId);
        /// <summary>
        /// Hàm kiểm tra mã tài sản đã tồn tại hay chưa
        /// </summary>
        /// <param name="assetCode">Mã tài sản cần check</param>
        /// <returns>True: đã tồn tại, False: chưa tồn tại</returns>
        /// CreatedBy: MTDUONG(16/06/2021)
        public bool CheckCodeExist(string assetCode);
    }
}
