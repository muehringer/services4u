using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Base.Infrastructure.Utilities
{
    public class EncryptionHelper
    {
        DESCryptoServiceProvider encryptionProvider = null;

        public EncryptionHelper()
        {
            encryptionProvider = new DESCryptoServiceProvider();
            encryptionProvider.KeySize = 64;

            encryptionProvider.IV = Convert.FromBase64String(System.Configuration.ConfigurationManager.AppSettings["CryptoVector"]);
            encryptionProvider.Key = Convert.FromBase64String(System.Configuration.ConfigurationManager.AppSettings["CryptoKey"]);
        }

        public string Criptografar(string text)
        {
            StringBuilder returnText = new StringBuilder();

            char[] convertContent = text.ToCharArray();
            byte[] convertedContent = new byte[convertContent.Length];

            int indexAC = 0;
            foreach (char symbol in convertContent)
            {
                convertedContent[indexAC] = Convert.ToByte(symbol);
                indexAC++;
            }

            byte[] returnContent = encryptionProvider.CreateEncryptor().TransformFinalBlock(convertedContent, 0, convertedContent.Length);

            return Convert.ToBase64String(returnContent);
        }

        public string Descriptografar(string text)
        {
            byte[] encryptedContent = Convert.FromBase64String(text);

            byte[] convertContent = encryptionProvider.CreateDecryptor().TransformFinalBlock(encryptedContent, 0, encryptedContent.Length);
            StringBuilder convertedContent = new StringBuilder();

            foreach (byte symbol in convertContent)
            {
                convertedContent.Append(Convert.ToChar(symbol));
            }

            return convertedContent.ToString();
        }
    }
}
