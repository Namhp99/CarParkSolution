using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DTO
{
    public class TripUpdateDTO
    {        
        public int TripId { get; set; }
        public int BookerTicketNumber { get; set; }
        public string CarType { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime DepartureTime { get; set; }
        public string Destination { get; set; }
        public string Driver { get; set; }
        public int MaximumOnlineTickerNumber { get; set; }
    }
}
