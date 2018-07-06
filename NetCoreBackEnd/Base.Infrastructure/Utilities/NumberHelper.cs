using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Infrastructure
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
