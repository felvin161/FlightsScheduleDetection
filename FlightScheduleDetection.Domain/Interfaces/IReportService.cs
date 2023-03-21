

using FlightScheduleDetection.Domain.Models;
using System.Collections.Generic;

namespace FlightScheduleDetection.Domain.Interfaces
{
    public interface IReportService
    {
        void GenerateReport(List<FlightDetailsModel> flightDetails);
    }
}
