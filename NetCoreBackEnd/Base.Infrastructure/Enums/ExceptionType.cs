using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Base.Infrastructure
{
    public enum ExceptionType
    {
        [Description("Ok")]
        Ok = 0,
        [Description("Error")]
        Error = 1,
    }
}
