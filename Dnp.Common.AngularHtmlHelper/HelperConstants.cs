﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnp.Common.AngularHtmlHelper
{
    internal static class HelperConstants
    {
        internal static Dictionary<DataType, string> DataTypeMapping = new Dictionary<DataType, string>();
        
        static HelperConstants()
        {
            DataTypeMapping.Add(DataType.EmailAddress, "email");
            DataTypeMapping.Add(DataType.Password, "password");
            DataTypeMapping.Add(DataType.Text, "text");
            DataTypeMapping.Add(DataType.MultilineText, "textarea");
            DataTypeMapping.Add(DataType.Date, "date");
            DataTypeMapping.Add(DataType.DateTime, "datetime");
        }
    }
}
