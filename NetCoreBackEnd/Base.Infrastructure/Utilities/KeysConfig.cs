using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Infrastructure
{
    public class KeysConfig
    {
        public string TypeDB { get; set; }
        public string ConnectionDB { get; set; }
        public string EmailFrom { get; set; }
        public string From { get; set; }
        public string SmtpServer { get; set; }
        public string SmtpPort { get; set; }
        public string SmtpUser { get; set; }
        public string SmtpPassword { get; set; }
        public string CryptoVector { get; set; }
        public string CryptoKey { get; set; }
    }
}
