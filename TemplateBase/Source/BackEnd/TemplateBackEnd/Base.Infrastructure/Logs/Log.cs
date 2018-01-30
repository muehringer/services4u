using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Infrastructure.Logs
{
    public static class Log
    {
        private static Logger _log = null;

        public static void Register()
        {
            if (_log == null) {
                _log = new LoggerConfiguration()
                    .ReadFrom.AppSettings("log")
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

        public static void Debug(string message)
        {
            _log.Debug(message);
        }

        public static void Debug(string message, params object[] values)
        {
            _log.Debug(message, values);
        }

        public static void Error(Exception ex, string message = "")
        {
            _log.Error(ex, message);
        }

        public static void Error(Exception ex, string message = "", params object[] values)
        {
            _log.Error(ex, message, values);
        }

        public static void Fatal(string message)
        {
            _log.Fatal("", message);
        }
    }
}
