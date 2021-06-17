using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entitites
{
    /// <summary>
    /// Loại tài sản
    /// CreatedBy MTDUONG(17/06/2021)
    /// </summary>
    public class AssetType
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid AssetTypeId { get; set; }
        /// <summary>
        /// Mã loại tài sản
        /// </summary>
        public string AssetTypeCode { get; set; }
        /// <summary>
        /// Tên loại tài sản
        /// </summary>
        public string AssetTypeName { get; set; }
        /// <summary>
        /// Mô tả
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Người tạo
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Ngày chỉnh sửa
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
        /// <summary>
        /// Người chỉnh sửa
        /// </summary>
        public string ModifiedBy { get; set; }

    }
}
