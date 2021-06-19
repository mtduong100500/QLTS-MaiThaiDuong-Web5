﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entitites
{
    class MISAttribute
    {
        [AttributeUsage(AttributeTargets.Property)]
        public class MISARequired : Attribute
        {

        }

        public class MISAEntityCode : Attribute
        {
        }
    }
}
