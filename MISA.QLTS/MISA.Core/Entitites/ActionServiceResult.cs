using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MISA.Core.Enumeration;

namespace MISA.Core.Entitites
{
    /// <summary>
    /// Kết quả trả về
    /// CreatedBy MTDUONG (21/06/2021)
    /// </summary>
    public class ActionServiceResult
    {
        /// <summary>
        /// Trạng thái 
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// Thông điệp
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Mã trả về từ APi
        /// </summary>
        public MISAcode MISAcode { get; set; }
        /// <summary>
        /// Dữ liệu trả về
        /// </summary>
        public object Data { get; set; }
    }
}
