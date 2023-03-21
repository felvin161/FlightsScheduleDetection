

using FlightScheduleDetection.Domain.Enums;
using FlightScheduleDetection.Domain.Exceptions;
using System;
using System.Text;

namespace FlightScheduleDetection.Domain.Validations
{
    public class GetScheduledFlightChangesServerValidator : ValidationBase
    {
        public override void validate(params object[] values)
        {

            if (!IsValidDate(values[0].ToString(), out DateTime startDate))
            {
                throw new ValidationException($"Invalid input. propertyName : {nameof(startDate)}. ExceptionTYpe : {ExceptionCodeType.InValidStartDate}");
            }
            if (!IsValidDate(values[1].ToString(), out DateTime endDate))
            {
                throw new ValidationException($"Invalid input. propertyName : {nameof(endDate)}. ExceptionTYpe : {ExceptionCodeType.InvalidEndDate}");
            }
            if (!IsValidInt(values[2].ToString(), out int agencyId))
            {
                throw new ValidationException($"Invalid input. propertyName : {nameof(agencyId)}. ExceptionTYpe : {ExceptionCodeType.InvalidAgency}");
            }
            if (startDate > endDate)
            {
                throw new ValidationException($"EndDate cannot be less than StartDate. ExceptionTYpe : {ExceptionCodeType.EndDateGraterThanStartDate}");
            }
        }
    }
}
