
using FlightScheduleDetection.DataAccess.DataBase;
using FlightScheduleDetection.Domain.Constants;
using FlightScheduleDetection.Domain.Exceptions;
using FlightScheduleDetection.Domain.Interfaces;
using FlightScheduleDetection.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;

namespace FlightScheduleDetection.DataAccess
{
    public class FlightsSchedule : IFlightsScheduleService
    {
        public List<FlightDetailsModel> GetScheduledFlightChanges(DateTime startDate, DateTime EndDate, int agencyID)
        {
            List<FlightDetailsModel> flights = new List<FlightDetailsModel>();

            using (FlightsScheduleDBContext db = new FlightsScheduleDBContext())
            {
                var watch = new Stopwatch();
                watch.Start();

                var scheduledFlights = GetFlightsDetailsForPeriod(db, startDate, EndDate, agencyID);
                
                var historyOfScheduledFlights = GetFlightsDetailsForPeriod(db, startDate.AddDays(Settings.NoOfDaysToSubtract), EndDate.AddDays(Settings.NoOfDaysToSubtract), agencyID);
                
                var scheduledFlightsForFuture = GetFlightsDetailsForPeriod(db, startDate.AddDays(Settings.NoOfDaysToAdd), EndDate.AddDays(Settings.NoOfDaysToAdd), agencyID);

                var newFlights = (from f in scheduledFlights
                                  join s in historyOfScheduledFlights on
                                  new { f.OriginCityID, f.DestinationCityID, f.AirlineID, adte = (DateTime)DbFunctions.AddDays(f.DepartureTime, Settings.NoOfDaysToSubtract) } equals
                                  new { s.OriginCityID, s.DestinationCityID, s.AirlineID, adte = s.DepartureTime } into result
                                  from r in result.DefaultIfEmpty()
                                  where r == null
                                  select new FlightDetailsModel
                                  {
                                      RouteID = f.RouteID,
                                      OriginCityID = f.OriginCityID,
                                      DestinationCityID = f.DestinationCityID,
                                      DepartureDate = f.DepartureDate,
                                      FlightID = f.FlightID,
                                      AirlineID = f.AirlineID,
                                      DepartureTime = f.DepartureTime,
                                      ArrivalTime = f.ArrivalTime,
                                      AgencyID = f.AgencyID,
                                      Status = FlightStatusType.New 
                                  }).ToList();

                //var newFlights = (from s in scheduledFlights
                //                where !historyOfScheduledFlights.Any(h => s.OriginCityID == h.OriginCityID && s.DestinationCityID == h.DestinationCityID
                //                && s.AirlineID == h.AirlineID && (DbFunctions.AddDays(s.DepartureTime, Settings.NoOfDaysToSubtract) >= DbFunctions.AddMinutes(h.DepartureTime, Settings.MinutesToSubtract)
                //                && DbFunctions.AddDays(s.DepartureTime, Settings.NoOfDaysToSubtract) <= DbFunctions.AddMinutes(h.DepartureTime, Settings.MinuteToAdd)))
                //                select s).ToList();

                var discontinuedFlights = (from f in scheduledFlights
                                           join s in scheduledFlightsForFuture on
                                           new { f.OriginCityID, f.DestinationCityID, f.AirlineID, adte = (DateTime)DbFunctions.AddDays(f.DepartureTime, Settings.NoOfDaysToAdd) } equals
                                           new { s.OriginCityID, s.DestinationCityID, s.AirlineID, adte = s.DepartureTime } into result
                                           from r in result.DefaultIfEmpty()
                                           where r == null
                                           select new FlightDetailsModel {
                                               RouteID = f.RouteID,
                                               OriginCityID = f.OriginCityID,
                                               DestinationCityID = f.DestinationCityID,
                                               DepartureDate = f.DepartureDate,
                                               FlightID = f.FlightID,
                                               AirlineID = f.AirlineID,
                                               DepartureTime = f.DepartureTime,
                                               ArrivalTime = f.ArrivalTime,
                                               AgencyID = f.AgencyID,
                                               Status = FlightStatusType.Discontinued
                                           }).ToList();

                flights.AddRange(newFlights);
                flights.AddRange(discontinuedFlights);

                watch.Stop();
                TimeSpan timeTaken = watch.Elapsed;
                Console.WriteLine($"Time taken to complete the flight detection algorithm is {timeTaken}");
                return flights;
            }
        }

        private IQueryable<FlightDetailsModel> GetFlightsDetailsForPeriod(FlightsScheduleDBContext db, DateTime startDate, DateTime EndDate, int agencyID)
        {
            return (from rt in db.routes
                    join fl in db.flights on rt.route_id equals fl.route_id
                    join ag in db.subscriptions on new { rt.origin_city_id, rt.destination_city_id } equals new { ag.origin_city_id, ag.destination_city_id }
                    where ag.agency_id == agencyID && (rt.departure_date >= startDate && rt.departure_date <= EndDate)
                    select new FlightDetailsModel
                    {
                        RouteID = rt.route_id,
                        OriginCityID = rt.origin_city_id,
                        DestinationCityID = rt.destination_city_id,
                        DepartureDate = rt.departure_date,
                        FlightID = fl.flight_id,
                        AirlineID = fl.airline_id,
                        DepartureTime = fl.departure_time,
                        ArrivalTime = fl.arrival_time,
                        AgencyID = ag.agency_id,
                        Status = FlightStatusType.Unknown
                    });
        }
    }
}
