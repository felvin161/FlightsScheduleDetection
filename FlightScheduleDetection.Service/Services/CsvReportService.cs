
using CsvHelper;
using FlightScheduleDetection.Domain.Interfaces;
using FlightScheduleDetection.Domain.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace FlightScheduleDetection.Service.Services
{
    public class CsvReportService : IReportService
    {
        private const string csvReportPath = @"C:\CSVReports";
        public void GenerateReport(List<FlightDetailsModel> flightDetails)
        {
            Log.Information("Generating CSV Reports");
            Console.WriteLine("Generating CSV Reports........");

            var csvPath = Path.Combine(csvReportPath, $"FlightSchedule-{DateTime.Now.ToFileTime()}.csv");

            using (var streamwritter = new StreamWriter(csvPath))
            {
                using (var csvWriter = new CsvWriter(streamwritter, CultureInfo.InvariantCulture))
                {
                    csvWriter.WriteRecords(flightDetails);
                }
            }

            Log.Information("CSV Reports Generated.");
            Console.WriteLine("CSV Reports Generated.");
        }
    }
}
