using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities
{
    public class Trip
    {
        public int TripId { get; set; }
        public int BookerTicketNumber { get; set; }
        public string CarType { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime DepartureTime { get; set; }
        public string Destination { get; set; }
        public string Driver { get; set; }
        public int MaximumOnlineTickerNumber { get; set; }
        public List<Ticket> Tickets { get; set; }
        public List<BookingOffice> BookingOffices { get; set; }
    }
}
