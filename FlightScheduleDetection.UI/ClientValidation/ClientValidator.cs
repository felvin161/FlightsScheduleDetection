
using Serilog;
using System;
using System.Collections.Generic;

namespace FlightScheduleDetection.UI.ClientValidation
{
    public  abstract class ClientValidator : IDisposable
    {
        internal static List<string> vailidationErrors = new List<string>();

        public abstract void validate(params object[] values);

        internal static bool IsValidDate(string inputDate, out DateTime date)
        {          
            return DateTime.TryParse(inputDate, out date);
        }

        internal static bool IsValidInt(string input, out int value)
        {
            return int.TryParse(input, out value);
        }
        internal static void CaptureValidationErrors(string message)
        {
            Console.WriteLine(message);
            Log.Warning(message);
            vailidationErrors.Add(message);
        }

        public void Dispose() {}
    }
}
