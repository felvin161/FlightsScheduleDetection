
using FlightScheduleDetection.DataAccess;
using FlightScheduleDetection.Service.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FlightScheduleDetection.UnitTests
{
    [TestClass]
    public class FlightServiceTest
    {
        [TestMethod]
        public void GetScheduledFlightChanges()
        {
            var _flightSchedule = new FlightsSchedule();
            var csvReportService = new CsvReportService();

            var service = new FlightService(_flightSchedule, csvReportService);

            DateTime startDate = new DateTime(2017, 01, 01);
            DateTime endDate = new DateTime(2017, 01, 10);
            int agencyID = 2;

            service.GetScheduledFlightChanges(startDate, endDate, agencyID);
        }
    }
}
