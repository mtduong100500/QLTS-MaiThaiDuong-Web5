using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core
{
    public class Enumeration
    {
        /// <summary>
        /// Mã code trả về client
        /// 200: Thành công
        /// 500: Lỗi server
        /// 400: Lỗi Bad request
        /// </summary>
        /// CreatedBy: MTDUONG (21/06/2021)
        public enum MISAcode
        {
            Success = 200,
            /// <summary>
            /// Lỗi vadidate dùng chung
            /// </summary>
            Validate = 400,
            /// <summary>
            /// Lỗi validate dữ liệu do không đúng nghiệp vụ
            /// </summary>
            ValidateBusiness = 402,
        }
        public enum InsertError
        {
            /// <summary>
            /// Hợp lệ
            /// </summary>
            Valid = 1,
            /// <summary>
            /// Trùng lặp
            /// </summary>
            DuplicateCode = 2
        }

    }
}
