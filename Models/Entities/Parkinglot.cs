using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Entities
{
    public class Parkinglot
    {
        public int ParkId { get; set; }
        public int ParkArea { get; set; }
        public string ParkName { get; set; }
        public string ParkPlace { get; set; }
        public int ParkPrice { get; set; }
        public string ParkStatus { get; set; }
        public List<Car> Cars { get; set; }
    }
}
