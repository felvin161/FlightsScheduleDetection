
using FlightScheduleDetection.UI.DependencyInjector;
using FlightScheduleDetection.UI.SerilogConfiguration;
using Serilog;
using System;
using Unity;

namespace FlightScheduleDetection.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            SeriLogger.InitializeSeriLog();

            var container = UnityContainerConfig.InitializeUnityContainer();
            Application_Start app = container.Resolve<Application_Start>();

            Log.Information("Application started");

            Console.WriteLine("Application started\n");

            //app.Run("2017-12-01", "2017-12-31", 1);
            if (args.Length == 3)
            {
                app.Run(args[0], args[1], args[2]);
            }
            else
            {
                Console.WriteLine("Applicaition Accepts only command line parameters\nPlease call this apllication in the following formats below:\nApplicationName StartDate(YYYY-DD-MM) EndDate(YYYY-DD-MM) AgencyId ");
            }
            Log.Information("Application End");
            Console.ReadLine();
        }
    }
}
