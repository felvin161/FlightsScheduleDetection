
using System;

namespace FlightScheduleDetection.UI.ClientValidation
{
    internal class ApplicaiionRunClientValidator : ClientValidator
    {
        public override void validate(params object[] values)
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
                vailidationErrors.Clear();
                throw new ArgumentException("Invalid Inputs");        
            }
        }
    }
}
