using Models.Entities;
using Models.GenericRepository;
using Models.View.BookOffices;
using Models.View.Pagging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repository.Interfaces
{
    public interface IBookingOfficeRepository : IGenericRepository<BookingOffice>
    {
        Task<PagedResult<BookingOffice>> GetAllRecords();
        Task<PagedResult<BookingOffice>> Find(GetPaggingRequest request);
    }
}
