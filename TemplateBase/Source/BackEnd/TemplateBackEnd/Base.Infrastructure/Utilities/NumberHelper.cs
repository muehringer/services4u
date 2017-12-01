using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Infrastructure.Utilities
{
    public class NumberHelper
    {
        public static bool ValidarNumero(string numero)
        {
            try
            {
                Int64 result = Int64.Parse(numero);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
