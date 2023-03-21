
using FlightScheduleDetection.DataAccess;
using FlightScheduleDetection.Domain.Interfaces;
using FlightScheduleDetection.Service.Services;
using Unity;

namespace FlightScheduleDetection.UI.DependencyInjector
{
    internal class UnityContainerConfig
    {
        internal static IUnityContainer _container;

        internal static IUnityContainer InitializeUnityContainer()
        {
            _container = new UnityContainer();
            _container.RegisterType<IFlightsScheduleService, FlightsSchedule>();
            _container.RegisterType<IFlightService, FlightService>();
            _container.RegisterType<IReportService, CsvReportService>();
            _container.RegisterType<IApplication_Start, Application_Start>();

            return _container;
        }
    }
}
