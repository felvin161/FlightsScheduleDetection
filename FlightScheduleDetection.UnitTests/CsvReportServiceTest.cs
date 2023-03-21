using FlightScheduleDetection.Domain.Models;
using FlightScheduleDetection.Service.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace FlightScheduleDetection.UnitTests
{
    [TestClass]
    public class CsvReportServiceTest
    {
        [TestMethod]
        public void GenerateReport()
        {
            var reportservice = new CsvReportService();

            List<FlightDetailsModel> flightDetails = new List<FlightDetailsModel>()
            {
                new FlightDetailsModel(){ RouteID = 360143, OriginCityID = 925, DestinationCityID = 1294, DepartureDate = new DateTime(2018,01,15), AgencyID = 1, FlightID = 7574391, AirlineID = 55, DepartureTime = new DateTime(), ArrivalTime =  new DateTime()},
                new FlightDetailsModel(){ RouteID = 360300, OriginCityID = 1192, DestinationCityID = 1118, DepartureDate = new DateTime(2018,01,16), AgencyID = 2, FlightID = 7563040, AirlineID = 3, DepartureTime = new DateTime(), ArrivalTime =  new DateTime()},
                new FlightDetailsModel(){ RouteID = 360094, OriginCityID = 1046, DestinationCityID = 1294, DepartureDate = new DateTime(2018,01,15), AgencyID = 3, FlightID = 7563034, AirlineID = 2, DepartureTime = new DateTime(), ArrivalTime =  new DateTime()},
                new FlightDetailsModel(){ RouteID = 360244, OriginCityID = 3863, DestinationCityID = 1046, DepartureDate = new DateTime(2018,02,10), AgencyID = 5, FlightID = 7563029, AirlineID = 5, DepartureTime = new DateTime(), ArrivalTime =  new DateTime()},
                new FlightDetailsModel(){ RouteID = 360094, OriginCityID = 5330, DestinationCityID = 1118, DepartureDate = new DateTime(2018,04,13), AgencyID = 3, FlightID = 7562992, AirlineID = 23, DepartureTime = new DateTime(), ArrivalTime =  new DateTime()},
            };

            reportservice.GenerateReport(flightDetails);
        }
    }
}
