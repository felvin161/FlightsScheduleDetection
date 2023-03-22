
using Serilog;
using System.Configuration;
using System.IO;

namespace FlightScheduleDetection.UI.SerilogConfiguration
{
    internal static class SeriLogger
    {
        internal static void InitializeSeriLog()
        {
            string logPath = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName + ConfigurationManager.AppSettings["SerilogPath"];
            Log.Logger = new LoggerConfiguration().
                            WriteTo.File(logPath, rollingInterval: RollingInterval.Day).
                            CreateLogger();
        }
    }
}
