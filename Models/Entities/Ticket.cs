using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public DateTime BookingTime { get; set; }
        public string CustomerName { get; set; }
        public string LicensePlate { get; set; }
        public int TripId { get; set; }
        public Trip Trip { get; set; }
        public Car Car { get; set; }
    }
}
