using Models.EF;
using Models.Entities;
using Services.GenericRespository;
using Services.Implement;
using Services.Interfaces;
using Services.Service;
using Services.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.UnitofWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly CarParkDbContext _context;
        public UnitOfWork(CarParkDbContext context)
        {
            _context = context;
            Cars = new CarService(_context);
            Trips = new TripService(_context);
            BookingOffices = new BookingOfficeService(_context);
            Employees = new EmployeeService(_context);
            Parkinglots = new ParkinglotService(_context);
            Tickets = new TicketService(_context);
        }
        public ICarService Cars { get; private set; }

        public ITripService Trips { get; private set; }

        public IBookingOfficeService BookingOffices { get; private set; }

        public IEmployeeService Employees { get; private set; }

        public IParkinglotService Parkinglots { get; private set; }

        public ITicketService Tickets { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
