
using System;
using System.Collections.Generic;

namespace FlightScheduleDetection.Domain.Validations
{
    public abstract class ValidationBase : IDisposable
    {
        public abstract void Validate(params object[] values);
        public void Dispose() { }

        internal static bool IsValidDate(string inputDate, out DateTime date)
        {
            return DateTime.TryParse(inputDate, out date);
        }

        internal static bool IsValidInt(string input, out int value)
        {
            return int.TryParse(input, out value);
        }
    }
}
