
using FlightScheduleDetection.Domain.Interfaces;
using FlightScheduleDetection.UI.ClientValidation;
using Serilog;
using System;
using System.Collections.Generic;

namespace FlightScheduleDetection.UI
{
    public class Application_Start : IApplication_Start
    {
        private readonly IFlightService _flightService;

        public Application_Start(IFlightService flightService)
        {
            _flightService = flightService;
        }
        public void Run(params object[] values)
        {
            try
            {
                using (var validator = new ApplicaiionRunClientValidator())
                {
                    validator.Validate(values);
                }
                
                _flightService.GetScheduledFlightChanges(DateTime.Parse(values[0].ToString()), DateTime.Parse(values[1].ToString()), int.Parse(values[2].ToString()));

            }
            catch (Exception ex)
            {
                Log.Error($"Exception from Method Run() {ex}");
            }
        }
    }
}
