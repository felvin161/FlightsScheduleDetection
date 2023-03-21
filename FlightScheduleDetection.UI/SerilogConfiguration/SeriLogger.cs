
using Serilog;
using System.Configuration;

namespace FlightScheduleDetection.UI.SerilogConfiguration
{
    internal static class SeriLogger
    {
        internal static void InitializeSeriLog()
        {
            Log.Logger = new LoggerConfiguration().
                            WriteTo.File(ConfigurationManager.AppSettings["SerilogPath"], rollingInterval: RollingInterval.Day).
                            CreateLogger();
        }
    }
}
