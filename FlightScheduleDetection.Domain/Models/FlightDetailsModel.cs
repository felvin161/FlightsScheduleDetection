
using FlightScheduleDetection.Domain.Exceptions;
using System;

namespace FlightScheduleDetection.Domain.Models
{
    public class FlightDetailsModel
    {
        public int RouteID { get; set; }
        public int OriginCityID { get; set; }
        public int DestinationCityID { get; set; }
        public DateTime DepartureDate { get; set; }
        public int FlightID { get; set; }
        public int AirlineID { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int AgencyID { get; set; }
        public FlightStatusType Status { get; set; }
    }
}
