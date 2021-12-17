using Microsoft.EntityFrameworkCore;
using Models.EF;
using Models.Entities;
using Models.View.BookOffices;
using Models.View.Pagging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BookingOffices
{
    public class BookOfficeService : IBookOfficeService
    {
        private readonly CarParkDbContext _context;
        public BookOfficeService(CarParkDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(BookCreateRequest request)
        {
            var trip = await _context.Trips.FindAsync(request.TripId);
            if(trip == null) throw new Exception("Khong tim ton tai chuyen");
            var bookOffice = new BookingOffice()
            {
                OfficeName = request.OfficeName,
                OfficePhone = request.OfficePhone,
                OfficePlace = request.OfficePlace,
                OfficePrice = request.OfficePrice,
                EndContractDeadline = request.EndContractDeadline,
                StartContractDeadline = request.StartContractDeadline,
                TripId = request.TripId,
            };
            _context.BookingOffices.Add(bookOffice);
            await _context.SaveChangesAsync();
            return bookOffice.OfficeId;
        }

        public async Task<int> Delete(int Id)
        {
            var bookingOffice = await _context.BookingOffices.FindAsync(Id);
            if (bookingOffice == null) throw new Exception("Khong tim thay phong");
            _context.BookingOffices.Remove(bookingOffice);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<BookView>> GetAll()
        {
            return await _context.BookingOffices.Select(i => new BookView()
            {
                OfficeName = i.OfficeName,
                OfficePhone = i.OfficePhone,
                OfficePlace = i.OfficePlace,
                OfficePrice = i.OfficePrice,
                EndContractDeadline = i.EndContractDeadline,
                StartContractDeadline = i.StartContractDeadline,
                TripId = i.TripId,
            }).ToListAsync();
        }

        public async Task<BookView> GetById(int Id)
        {
            var bookingOffice = await _context.BookingOffices.FindAsync(Id);
            if (bookingOffice == null) throw new Exception("Khong tim thay phong");
            var viewOffice = new BookView()
            {
                OfficeName = bookingOffice.OfficeName,
                OfficePhone = bookingOffice.OfficePhone,
                OfficePlace = bookingOffice.OfficePlace,
                OfficePrice = bookingOffice.OfficePrice,
                EndContractDeadline = bookingOffice.EndContractDeadline,
                StartContractDeadline = bookingOffice.StartContractDeadline,
                TripId = bookingOffice.TripId,
            };
            return viewOffice;
        }

        public async Task<PagedResult<BookView>> GetOfficePaging(GetPaggingRequest request)
        {
            //1/Select join
            var query = from p in _context.BookingOffices
                        select new { p };
            //2.filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.p.OfficeName.Contains(request.Keyword)
                                 || x.p.OfficePhone.Contains(request.Keyword)
                                 || x.p.OfficePlace.Contains(request.Keyword));
            //3.Paging
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(i => new BookView()
                {
                    OfficeName = i.p.OfficeName,
                    OfficePhone = i.p.OfficePhone,
                    OfficePlace = i.p.OfficePlace,
                    OfficePrice = i.p.OfficePrice,
                    EndContractDeadline = i.p.EndContractDeadline,
                    StartContractDeadline = i.p.StartContractDeadline,
                    TripId = i.p.TripId,
                }).ToListAsync();
            //4. Select and projection
            var pagedResult = new PagedResult<BookView>()
            {
                TotalRecord = totalRow,
                Items = data
            };
            return pagedResult;
        }

        public async Task<int> Update(BookUpdateRequest request)
        {
            var bookOffice = await _context.BookingOffices.FindAsync(request.OfficeId);
            if (bookOffice == null) throw new Exception("Khong tim thay phong");
            bookOffice.OfficeName = request.OfficeName;
            bookOffice.OfficePhone = request.OfficePhone;
            bookOffice.OfficePlace = request.OfficePlace;
            bookOffice.OfficePrice = request.OfficePrice;
            bookOffice.TripId = request.TripId;
            bookOffice.StartContractDeadline = request.StartContractDeadline;
            bookOffice.EndContractDeadline = request.EndContractDeadline;
            return await _context.SaveChangesAsync();
        }
    }
}
