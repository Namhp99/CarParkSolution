using AutoMapper;
using Models.EF;
using Models.Entities;
using Models.View.BookOffices;
using Models.View.Pagging;
using Services.GenericRespository;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Services.Implement
{
    public class BookingOfficeService : GenericRespository<BookingOffice>, IBookingOfficeService
    {

        public BookingOfficeService(CarParkDbContext context)
            : base(context)
        {
        }

        //public async Task<int> Create(BookCreateRequest request)
        //{
        //    var config = new MapperConfiguration(cfg =>
        //    {
        //        cfg.CreateMap<BookCreateRequest, BookingOffice>();
        //    });
        //    var mapper = config.CreateMapper();
        //    BookingOffice bookingOffice = mapper.Map<BookingOffice>(request);
        //    _context.BookingOffices.Add(bookingOffice);
        //    await _context.SaveChangesAsync();
        //    return bookingOffice.OfficeId;
        //}

        public async Task<PagedResult<BookingOffice>> Find(GetPaggingRequest request)
        {
            //1/Select join
            var query = from p in _context.BookingOffices
                        join t in _context.Trips on p.TripId equals t.TripId
                        select new { p , t };
            //2.filter
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                if (request.KeyType == "OfficeName")
                    query = query.Where(x => x.p.OfficeName.Contains(request.Keyword));
                if (request.KeyType == "OfficePhone")
                    query = query.Where(x => x.p.OfficePhone.Contains(request.Keyword));
                if (request.KeyType == "OfficePlace")
                    query = query.Where(x => x.p.OfficePlace.Contains(request.Keyword));
                else query = query.Where(x => x.p.OfficeName.Contains(request.Keyword)
                                         || x.p.OfficePhone.Contains(request.Keyword)
                                         || x.p.OfficeName.Contains(request.Keyword));
            }
            //3.Paging
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(i => new BookingOffice()
                {
                    OfficeId = i.p.OfficeId,
                    EndContractDeadline = i.p.EndContractDeadline,
                    OfficeName = i.p.OfficeName,
                    OfficePhone = i.p.OfficePhone,
                    OfficePlace = i.p.OfficePlace,
                    OfficePrice = i.p.OfficePrice,
                    StartContractDeadline = i.p.StartContractDeadline,
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
                    }
                }).ToListAsync();
            //4. Select and projection
            var pagedResult = new PagedResult<BookingOffice>()
            {
                TotalRecord = totalRow,
                Items = data
            };
            return pagedResult;
        }

        public async Task<PagedResult<BookingOffice>> GetAllRecords()
        {
            // Select join
            var query = from p in _context.BookingOffices
                            //join t in _context.Trips on p.TripId equals t.TripId
                        select new { p };
            //2.filter           
            //3.Paging
            int totalRow = await query.CountAsync();
            var data = query
                .Select(i => new BookingOffice()
                {
                    OfficeId = i.p.OfficeId,
                    EndContractDeadline = i.p.EndContractDeadline,
                    OfficeName = i.p.OfficeName,
                    OfficePhone = i.p.OfficePhone,
                    OfficePlace = i.p.OfficePlace,
                    OfficePrice = i.p.OfficePrice,
                    StartContractDeadline = i.p.StartContractDeadline,
                    TripId = i.p.TripId,
                    Trip = i.p.Trip

                }).ToList();
            //4. Select and projection
            var pagedResult = new PagedResult<BookingOffice>()
            {
                TotalRecord = totalRow,
                Items = data
            };
            return pagedResult;
        }

        //public async Task<int> Update(BookUpdateRequest request)
        //{
        //    var booking = await _context.BookingOffices.FindAsync(request.OfficeId);
        //    if (booking == null) return -1;
        //    booking.EndContractDeadline = request.EndContractDeadline;
        //    booking.OfficeName = request.OfficeName;
        //    booking.OfficePhone = request.OfficePhone;
        //    booking.OfficePlace = request.OfficePlace;
        //    booking.OfficePrice = request.OfficePrice;
        //    booking.StartContractDeadline = request.StartContractDeadline;
        //    booking.TripId = request.TripId;
        //    return await _context.SaveChangesAsync();
        //}
    }
}
