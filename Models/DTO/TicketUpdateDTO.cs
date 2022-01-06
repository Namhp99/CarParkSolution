using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DTO
{
    public class TicketUpdateDTO
    {        
        public int TicketId { get; set; }
        public DateTime BookingTime { get; set; }
        public string CustomerName { get; set; }
        public string LicensePlate { get; set; }
        public int TripId { get; set; }
    }
}
