using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DTO
{
    public class ParkinglotDTO
    {
        public int ParkId { get; set; }
        public int ParkArea { get; set; }
        public string ParkName { get; set; }
        public string ParkPlace { get; set; }
        public int ParkPrice { get; set; }
        public string ParkStatus { get; set; }
    }
}
