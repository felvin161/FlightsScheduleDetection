
using FlightScheduleDetection.Domain.Models;
using System;
using System.Collections.Generic;

namespace FlightScheduleDetection.Domain.Interfaces
{
    public interface IFlightsScheduleService
    {
        List<FlightDetailsModel> GetScheduledFlightChanges(DateTime startDate, DateTime EndDate, int agencyID);
    }
}
