
using FlightScheduleDetection.Domain.Models;
using System;
using System.Collections.Generic;

namespace FlightScheduleDetection.Domain.Interfaces
{
    public interface IFlightService
    {
        void GetScheduledFlightChanges(DateTime startDate, DateTime EndDate, int agencyID);
    }
}
