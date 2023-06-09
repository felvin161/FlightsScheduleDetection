﻿
using System;
using System.Text;

namespace FlightScheduleDetection.UI.ClientValidation
{
    internal class ApplicaiionRunClientValidator : ClientValidator
    {
        public override void Validate(params object[] values)
        {
            if (!IsValidDate(values[0].ToString(), out DateTime startDate))
            {
                CaptureValidationErrors($"invalid input propertyName {nameof(startDate)}");
            }
            if (!IsValidDate(values[1].ToString(), out DateTime endDate))
            {
                CaptureValidationErrors($"invalid input propertyName {nameof(endDate)}");
            }
            if (!IsValidInt(values[2].ToString(), out int agencyId))
            {
                CaptureValidationErrors($"invalid input propertyName {nameof(agencyId)}");
            }
            if(startDate > endDate)
            {
                CaptureValidationErrors($"EndDate cannot be less than StartDate");
            }

            if (vailidationErrors.Count != 0)
            {
                var sbError = new StringBuilder();
                vailidationErrors.ForEach(e => sbError.AppendFormat("{0}\n", e));
                Console.WriteLine(sbError);

                vailidationErrors.Clear();
                throw new ArgumentException("Invalid Inputs");        
            }
        }
    }
}
