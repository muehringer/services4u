using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Infrastructure
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

        public static RetornoValidacao ValidarLimiteDias(DateTime dataInicio, DateTime dataFim) {

            RetornoValidacao retorno = new RetornoValidacao();
            retorno.Resultado = false;

            var limite = Convert.ToInt32(15);//15 dias
            
            if (dataInicio < dataFim) {

                var datadiff = dataFim.Subtract(dataInicio).Days;

                if (datadiff < limite) {
                    retorno.Resultado = true;
                    retorno.Mensagem = "Sucesso.";
                } else {
                    retorno.Mensagem = "Range de data superior a 15 dias.";                
                }
            } else {
                retorno.Mensagem = "Data início maior que a data fim.";
            }

            return retorno;
        }
    }

    public class RetornoValidacao {

        public bool Resultado { get; set; }
        public string Mensagem { get; set; }

    }
}
