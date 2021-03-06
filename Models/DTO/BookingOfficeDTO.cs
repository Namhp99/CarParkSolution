using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DTO
{
    public class BookingOfficeDTO
    {
        //public int OfficeId { get; set; }
        public DateTime EndContractDeadline { get; set; }
        public DateTime StartContractDeadline { get; set; }
        public string OfficeName { get; set; }
        public string OfficePhone { get; set; }
        public string OfficePlace { get; set; }
        public int OfficePrice { get; set; }
        public int TripId { get; set; }
    }
}
