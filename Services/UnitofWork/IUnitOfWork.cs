using Models.Entities;
using Services.GenericRespository;
using Services.Interfaces;
using Services.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.UnitofWork
{
    public interface IUnitOfWork
    {
        ICarService Cars { get; }
        ITripService Trips { get; }
        IBookingOfficeService BookingOffices { get; }
        IEmployeeService Employees { get; }
        IParkinglotService Parkinglots { get; }
        ITicketService Tickets { get; }
        Task Save();
    }
}
