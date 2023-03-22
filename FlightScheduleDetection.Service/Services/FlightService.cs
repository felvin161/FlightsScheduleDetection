
using FlightScheduleDetection.Domain.Interfaces;
using FlightScheduleDetection.Domain.Validations;
using Serilog;
using System;

namespace FlightScheduleDetection.Service.Services
{
    public class FlightService : IFlightService
    {
        private readonly IFlightsScheduleService _flightsScheduleService;
        private readonly IReportService _reportService;

        public FlightService(IFlightsScheduleService flightsScheduleService, IReportService reportService)
        {
            _flightsScheduleService = flightsScheduleService;
            _reportService = reportService;
        }

        public void GetScheduledFlightChanges(DateTime startDate, DateTime endDate, int agencyID)
        {
            try
            {
                Console.WriteLine("Checking no of flights discontinued or newly added....");

                using (var validator = new GetScheduledFlightChangesServerValidator())
                {
                    validator.Validate(startDate, endDate, agencyID);
                }

                var flightsDetails = _flightsScheduleService.GetScheduledFlightChanges(startDate, endDate, agencyID);

                if (flightsDetails != null)
                {
                    Console.WriteLine($"Found {flightsDetails.Count} has changes");
                    _reportService.GenerateReport(flightsDetails);
                }
                else
                {
                    Console.WriteLine($"No Changes for the exisinting flights scheduling from {startDate} to {endDate}");
                    Log.Information($"No Changes for the exisinting flights scheduling from {startDate} to {endDate}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong. Please check log file for more information.");
                Log.Error($"Error from GetScheduledFlightChanges. {ex}");
                throw ex;
            }
        }
    }
}
