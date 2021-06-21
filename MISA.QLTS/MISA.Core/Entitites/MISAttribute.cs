using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entitites
{
    class MISAttribute
    {
        [AttributeUsage(AttributeTargets.Property)]
        /// <summary>
        /// Bắt buộc nhập
        /// </summary>
        public class MISARequired : Attribute
        {
            public string msg;
            public MISARequired(string msg)
            {
                this.msg = msg;
            }
        }
        /// <summary>
        /// Trùng mã
        /// </summary>
        public class MISAEntityCode : Attribute
        {
            public string msg;
            public MISAEntityCode(string msg)
            {
                this.msg = msg;
            }
        }
    }
}
