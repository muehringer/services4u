using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Infrastructure.Enums
{
    public enum ExceptionType
    {
        [Description("Ok")]
        Ok = 0,
        [Description("Error")]
        Error = 1,
    }
}
