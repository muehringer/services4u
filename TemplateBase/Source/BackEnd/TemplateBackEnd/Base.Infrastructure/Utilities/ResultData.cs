using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Infrastructure.Utilities
{
    public class ResultData<T>
    {
        public Int64 Identity { get; set; }
        public int ExceptionCode { get; set; }
        public string ExceptionMessage { get; set; }
        public string ExceptionStackTrace { get; set; }
        public List<T> Results { get; set; }
        public T Result { get; set; }

        public ResultData()
        {
            Results = new List<T>();
            Identity = 0;
            ExceptionCode = 0;
            ExceptionMessage = string.Empty;
            ExceptionStackTrace = string.Empty;
        }
    }
}
