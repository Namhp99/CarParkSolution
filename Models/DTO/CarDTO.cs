﻿using Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DTO
{
    public class CarDTO
    {
        public string LicensePlate { get; set; }
        public string CarColor { get; set; }
        public string CarType { get; set; }
        public string Company { get; set; }
        public int ParkId { get; set; }

    }
    
}
