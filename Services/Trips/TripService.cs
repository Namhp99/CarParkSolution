using Microsoft.EntityFrameworkCore;
using Models.EF;
using Models.Entities;
using Models.View.Pagging;
using Models.View.Trips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Trips
{
    public class TripService : ITripService
    {
        private readonly CarParkDbContext _context;
        public TripService(CarParkDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(TripCreateRequest request)
        {
            var trip = new Trip()
            {
                DepartureDate = request.DepartureDate,
                DepartureTime = request.DepartureDate,
                Destination = request.Destination,
                Driver = request.Driver,
                CarType = request.CarType,
                BookerTicketNumber = request.BookerTicketNumber,
                MaximumOnlineTickerNumber = request.MaximumOnlineTickerNumber
            };
            _context.Trips.Add(trip);
            await _context.SaveChangesAsync();
            return trip.TripId;
        }

        public async Task<int> Delete(int Id)
        {
            var trip = await _context.Trips.FindAsync(Id);
            if (trip == null) throw new Exception("Khong tim thay chuyen");
            _context.Trips.Remove(trip);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<TripView>> GetAll()
        {
            return await _context.Trips.Select(i => new TripView()
            {
                TripId = i.TripId,
                BookerTicketNumber = i.BookerTicketNumber,
                CarType = i.CarType,
                DepartureTime = i.DepartureTime,
                DepartureDate = i.DepartureDate,
                Destination = i.Destination,
                Driver = i.Driver,
                MaximumOnlineTickerNumber = i.MaximumOnlineTickerNumber,
            }).ToListAsync();
        }

        public async Task<TripView> GetById(int Id)
        {
            var trip = await _context.Trips.FindAsync(Id);
            if (trip == null) throw new Exception("Khong tim thay chuyen");
            var tripView = new TripView()
            {
                TripId = trip.TripId,
                CarType = trip.CarType,
                MaximumOnlineTickerNumber = trip.MaximumOnlineTickerNumber,
                BookerTicketNumber = trip.BookerTicketNumber,
                DepartureTime = trip.DepartureTime,
                Destination = trip.Destination,
                DepartureDate = trip.DepartureDate,
                Driver = trip.Driver
            };
            return tripView;
        }

        public Task<PagedResult<TripView>> GetTripPagging(GetPaggingRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(TripUpdateRequest request)
        {
            var trip = await _context.Trips.FindAsync(request.TripId);
            if (trip == null) throw new Exception("Khong tim thay nhan vien");
            trip.CarType = request.CarType;
            trip.DepartureDate = request.DepartureDate;
            trip.DepartureTime = request.DepartureTime;
            trip.BookerTicketNumber = request.BookerTicketNumber;
            trip.Destination = request.Destination;
            trip.Driver = request.Driver;
            trip.MaximumOnlineTickerNumber = request.MaximumOnlineTickerNumber;
            return await _context.SaveChangesAsync();
        }
    }
}
