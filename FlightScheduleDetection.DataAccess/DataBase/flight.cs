//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FlightScheduleDetection.DataAccess.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class flight
    {
        public int flight_id { get; set; }
        public int route_id { get; set; }
        public System.DateTime departure_time { get; set; }
        public System.DateTime arrival_time { get; set; }
        public int airline_id { get; set; }
    
        public virtual route route { get; set; }
    }
}
