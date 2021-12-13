using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities
{
    public class Car
    {
        public string LicensePlate { get; set; }
        public string CarColor { get; set; }
        public string CarType { get; set; }
        public string Company { get; set; }
        public int ParkId { get; set; }
        public Parkinglot Parkinglot { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}
