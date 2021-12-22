using System;
using System.Collections.Generic;
using System.Text;

namespace Models.View.Tickets
{
    public class TicketCreateRequest
    {
        public DateTime BookingTime { get; set; }
        public string CustomerName { get; set; }
        public string LicensePlate { get; set; }
        public int TripId { get; set; }
    }
}
