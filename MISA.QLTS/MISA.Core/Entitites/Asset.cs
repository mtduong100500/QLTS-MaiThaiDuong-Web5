using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MISA.Core.Entitites.MISAttribute;

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
        [MISARequired]
        [MISAEntityCode]
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
        /// <summary>
        /// Mã loại tài sản
        /// </summary>
        public string AssetTypeCode { get; set; }
        /// <summary>
        /// Tên loại tài sản
        /// </summary>
        public string AssetTypeName { get; set; }
        /// <summary>
        /// Mã phòng ban
        /// </summary>
        public string DepartmentCode { get; set; }
        /// <summary>
        /// Tên phòng ban
        /// </summary>
        public string DepartmentName { get; set; }
    }
}
