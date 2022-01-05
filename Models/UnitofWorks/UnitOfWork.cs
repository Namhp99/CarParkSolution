using Models.EF;
using Models.Entities;
using Models.Repository.Implement;
using Models.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Models.UnitofWorks
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly CarParkDbContext _context;
        public UnitOfWork(CarParkDbContext context)
        {
            _context = context;
            Cars = new CarRepository(_context);
            Trips = new TripRepository(_context);
            BookingOffices = new BookingOfficeRepository(_context);
            Employees = new EmployeeRepository(_context);
            Parkinglots = new ParkinglotRepository(_context);
            Tickets = new TicketRepository(_context);
        }
        public ICarRepository Cars { get; private set; }

        public ITripRepository Trips { get; private set; }

        public IBookingOfficeRepository BookingOffices { get; private set; }

        public IEmployeeRepository Employees { get; private set; }

        public IParkinglotRepository Parkinglots { get; private set; }

        public ITicketRepository Tickets { get; private set; }

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
