using AutoMapper;
using Models.EF;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Models.View.Pagging;
using Models.View.Trips;
using Services.GenericRespository;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Service
{
    public class TripService : GenericRespository<Trip>, ITripService
    {

        public TripService(CarParkDbContext context)
            : base(context)
        {
        }

        //public async Task<int> Create(TripCreateRequest request)
        //{
        //    var config = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<TripCreateRequest, Trip>();
        //    });
        //    var mapper = config.CreateMapper();
        //    Trip trip = mapper.Map<Trip>(request);
        //    _context.Trips.Add(trip);
        //    await _context.SaveChangesAsync();
        //    return trip.TripId;
        //}

        public async Task<PagedResult<Trip>> Find(GetPaggingRequest request)
        {
            //1/Select join
            var query = from p in _context.Trips
                        select new { p};
            //2.filter
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                if (request.KeyType == "CarType")
                    query = query.Where(x => x.p.CarType.Contains(request.Keyword));
                if (request.KeyType == "Destination")
                    query = query.Where(x => x.p.Destination.Contains(request.Keyword));
                if (request.KeyType == "Driver")
                    query = query.Where(x => x.p.Driver.Contains(request.Keyword));
                else query = query.Where(x => x.p.CarType.Contains(request.Keyword)
                        || x.p.Destination.Contains(request.Keyword)
                        || x.p.Driver.Contains(request.Keyword));
            }   
            
            //3.Paging
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(i => new Trip()
                {
                    TripId = i.p.TripId,
                    BookerTicketNumber = i.p.BookerTicketNumber,
                    CarType = i.p.CarType,
                    DepartureDate = i.p.DepartureDate,
                    DepartureTime = i.p.DepartureTime,
                    Destination = i.p.Destination,
                    Driver = i.p.Driver,
                    MaximumOnlineTickerNumber = i.p.MaximumOnlineTickerNumber,
                }).ToListAsync();
            //4. Select and projection
            var pagedResult = new PagedResult<Trip>()
            {
                TotalRecord = totalRow,
                Items = data
            };
            return pagedResult;
        }

        public async Task<PagedResult<Trip>> GetAllRecords()
        {
            // Select join
               var query = from p in _context.Trips
                           //join b in _context.BookingOffices on p.TripId equals b.TripId
                           //join t in _context.Tickets on p.TripId equals t.TripId
                           select new { p };
            //2.filter           
            //3.Paging
            int totalRow = await query.CountAsync();
            var data = query
                .Select(i => new Trip()
                {
                    TripId = i.p.TripId,
                    BookerTicketNumber = i.p.BookerTicketNumber,
                    CarType = i.p.CarType,
                    DepartureDate = i.p.DepartureDate,
                    DepartureTime = i.p.DepartureTime,
                    Destination = i.p.Destination,
                    Driver = i.p.Driver,
                    MaximumOnlineTickerNumber = i.p.MaximumOnlineTickerNumber,
                    BookingOffices = i.p.BookingOffices,
                    Tickets = i.p.Tickets

                }).ToList();
            //4. Select and projection
            var pagedResult = new PagedResult<Trip>()
            {
                TotalRecord = totalRow,
                Items = data
            };
            return pagedResult;
        }

        //public async Task<int> Update(TripUpdateRequest request)
        //{
        //    var trip = await _context.Trips.FindAsync(request.TripId);
        //    if (trip == null) return -1;
        //    trip.CarType = request.CarType;
        //    trip.DepartureDate = request.DepartureDate;
        //    trip.DepartureTime = request.DepartureTime;
        //    trip.BookerTicketNumber = request.BookerTicketNumber;
        //    trip.Destination = request.Destination;
        //    trip.Driver = request.Driver;
        //    trip.MaximumOnlineTickerNumber = request.MaximumOnlineTickerNumber;
        //    return await _context.SaveChangesAsync();
        //}
    }
}
