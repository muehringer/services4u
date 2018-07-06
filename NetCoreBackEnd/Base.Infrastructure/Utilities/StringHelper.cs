using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Infrastructure
{
    public class StringHelper
    {
        public static string FormatarTextoAcento(string text)
        {
            string withAccents = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç";
            string withoutAccents = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc";

            for (int i = 0; i < withAccents.Length; i++)
            {
                text = text.Replace(withAccents[i].ToString(), withoutAccents[i].ToString());
            }

            return text.ToUpper().Trim().Replace("'", "").Replace("&", " E ");
        }

        public static string FormatarTextoCaracteresInvalidos(string text)
        {
            string withAccents = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç";
            string withoutAccents = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc";

            for (int i = 0; i < withAccents.Length; i++)
            {
                text = text.Replace(withAccents[i].ToString(), withoutAccents[i].ToString());
            }

            return text.ToUpper().Trim().Replace("'", "").Replace("&", " E ").Replace(",", " ").Replace(":", " ").Replace("/", " ").Replace("-", " ").Replace(">", "").Replace("<", "").Replace("[", "").Replace("]", "").Replace("{", "").Replace("}", "").Replace(".", " ");
        }
    }
}
