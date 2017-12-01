using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Infrastructure.Utilities
{
    public class DateHelper
    {
        public static bool ValidarData(string data)
        {
            try
            {
                DateTime result = DateTime.Parse(data);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static DateTime CalcularDiaUtil(DateTime dataInicial, int quantidadeDias, bool eDiaUtil)
        {
            DateTime dataFinal = dataInicial;

            if (eDiaUtil)
            {
                for (int i = 1; i < quantidadeDias; i++)
                {
                    if (dataFinal.DayOfWeek != DayOfWeek.Saturday && dataFinal.DayOfWeek != DayOfWeek.Sunday)
                        dataFinal = dataFinal.AddDays(1);

                    if (i == 1 && dataFinal.DayOfWeek == DayOfWeek.Sunday)
                        dataFinal = dataFinal.AddDays(1);

                    if (dataFinal.DayOfWeek == DayOfWeek.Saturday)
                        dataFinal = dataFinal.AddDays(2);
                }
            }
            else
            {
                dataFinal = dataInicial.AddDays(quantidadeDias);
            }

            return dataFinal;
        }
    }
}
