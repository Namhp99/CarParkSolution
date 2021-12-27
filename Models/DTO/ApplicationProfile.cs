using Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DTO
{
    public class ApplicationProfile : AutoMapper.Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Car, CarDTO>()
                .ReverseMap();
            CreateMap<BookingOffice, BookingOfficeDTO>()
                .ReverseMap();
            CreateMap<Employee, EmployeeDTO>()
                .ReverseMap();
            CreateMap<Parkinglot, ParkinglotDTO>()
                .ReverseMap();
            CreateMap<Ticket, TicketDTO>()
                .ReverseMap();
            CreateMap<Trip, TripDTO>()
                .ReverseMap();
        }
    }
}
