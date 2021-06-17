using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entitites
{
    /// <summary>
    /// Tài sản
    /// CreateBy MTDUONG (16/06/2021)
    /// </summary>
    public class Asset
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid AssetId { get; set; }
        /// <summary>
        /// Mã tài sản
        /// </summary>
        public string AssetCode { get; set; }
        /// <summary>
        /// Tên tài sản
        /// </summary>
        public string AssetName { get; set; }
        /// <summary>
        /// Khóa phụ
        /// </summary>
        public Guid AssetTypeId { get; set; }
        /// <summary>
        /// Khóa phụ
        /// </summary>
        public Guid DepartmentId { get; set; }
        /// <summary>
        /// Ngày ghi tăng
        /// </summary>
        public DateTime? IncreaseDate { get; set; }
        /// <summary>
        /// Thời gian sử dụng
        /// </summary>
        public double? TimeUse { get; set; }
        /// <summary>
        /// Tỉ lệ hao mòn
        /// </summary>
        public double? WearRate { get; set; }
        /// <summary>
        /// Giá gốc
        /// </summary>
        public double? OriginalPrice { get; set; }
        /// <summary>
        /// Giá trị hao mòn năm
        /// </summary>
        public double? WearValue { get; set; }
        /// <summary>
        /// Đã sử dụng
        /// </summary>
        public int? IsUsed { get; set; }
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
