using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Infrastructure.Logs
{
    public static class LogAudit
    {
        private static Logger _log = null;

        public static void Register()
        {
            if (_log == null) {
                _log = new LoggerConfiguration()
                    .ReadFrom.AppSettings("audit")
                    .CreateLogger();

                _log.Debug("Log Criado");
            }
        }

        public static void Information(string message)
        {
            _log.Information(message);
        }

        public static void Information(string message, params object[] values)
        {
            _log.Information(message, values);
        }
    }
}
