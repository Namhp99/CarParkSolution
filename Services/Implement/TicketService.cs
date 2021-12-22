using AutoMapper;
using Models.EF;
using Models.Entities;
using Models.View.Pagging;
using Models.View.Tickets;
using Services.GenericRespository;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class TicketService : GenericRespository<Ticket>, ITicketService
    {

        public TicketService(CarParkDbContext context)
            : base(context)
        {
        }

        public async Task<int> Create(TicketCreateRequest request)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TicketCreateRequest, Ticket>();
            });
            var mapper = config.CreateMapper();
            Ticket ticket = mapper.Map<Ticket>(request);
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();
            return ticket.TripId;
        }

        public async Task<PagedResult<Ticket>> Find(GetPaggingRequest request)
        {
            //1/Select join
            var query = from p in _context.Tickets
                        join t in _context.Trips on p.TripId equals t.TripId
                        join c in _context.Cars on p.LicensePlate equals c.LicensePlate
                        select new { p, t, c};
            //2.filter
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                if (request.KeyType == "CustomerName")
                    query = query.Where(x => x.p.CustomerName.Contains(request.Keyword));
                if (request.KeyType == "LicensePlate")
                    query = query.Where(x => x.p.LicensePlate.Contains(request.Keyword));
                else query = query.Where(x => x.p.LicensePlate.Contains(request.Keyword)
                        || x.p.CustomerName.Contains(request.Keyword));
            }
            //3.Paging
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(i => new Ticket()
                {
                    TicketId = i.p.TicketId,
                    BookingTime = i.p.BookingTime,
                    CustomerName = i.p.CustomerName,
                    LicensePlate = i.p.LicensePlate,
                    TripId = i.p.TripId,
                    Trip = new Trip()
                    {
                        TripId = i.t.TripId,
                        BookerTicketNumber = i.t.BookerTicketNumber,
                        CarType = i.t.CarType,
                        DepartureDate = i.t.DepartureDate,
                        DepartureTime = i.t.DepartureTime,
                        Destination = i.t.Destination,
                        Driver = i.t.Driver,
                        MaximumOnlineTickerNumber = i.t.MaximumOnlineTickerNumber
                    },
                    Car = new Car()
                    {
                        LicensePlate = i.c.LicensePlate,
                        CarColor = i.c.CarColor,
                        CarType = i.c.CarType,
                        Company = i.c.Company,
                        ParkId = i.c.ParkId,
                    }
                    
                }).ToListAsync();
            //4. Select and projection
            var pagedResult = new PagedResult<Ticket>()
            {
                TotalRecord = totalRow,
                Items = data
            };
            return pagedResult;
        }

        public async Task<PagedResult<Ticket>> GetAllRecords()
        {
            // Select join
               var query = from p in _context.Tickets
                           //join t in _context.Trips on p.TripId equals t.TripId
                           select new { p };
            //2.filter           
            //3.Paging
            int totalRow = await query.CountAsync();
            var data = query
                .Select(i => new Ticket()
                {
                    TicketId =i.p.TicketId,
                    BookingTime = i.p.BookingTime,
                    CustomerName = i.p.CustomerName,
                    LicensePlate = i.p.LicensePlate,
                    TripId = i.p.TripId,
                    //Trip = new Trip()
                    //{
                    //    TripId = i.t.TripId,
                    //    BookerTicketNumber = i.t.BookerTicketNumber,
                    //    CarType = i.t.CarType,
                    //    DepartureDate = i.t.DepartureDate,
                    //    DepartureTime = i.t.DepartureTime,
                    //    Destination = i.t.Destination,
                    //    Driver = i.t.Driver,
                    //    MaximumOnlineTickerNumber = i.t.MaximumOnlineTickerNumber
                    //}
                    Trip = i.p.Trip,
                    Car =i.p.Car

                }).ToList();
            //4. Select and projection
            var pagedResult = new PagedResult<Ticket>()
            {
                TotalRecord = totalRow,
                Items = data
            };
            return pagedResult;
        }

        public async Task<int> Update(TicketUpdateRequest request)
        {
            var ticket = await _context.Tickets.FindAsync(request.TicketId);
            if (ticket == null) return -1;
            ticket.BookingTime = request.BookingTime;
            ticket.CustomerName = request.CustomerName;
            ticket.LicensePlate = request.LicensePlate;
            ticket.TripId = request.TripId;
            return await _context.SaveChangesAsync();
        }
    }
}
