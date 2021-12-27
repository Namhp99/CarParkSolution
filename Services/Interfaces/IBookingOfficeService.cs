using Models.Entities;
using Models.View.BookOffices;
using Models.View.Pagging;
using Services.GenericRespository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IBookingOfficeService : IGenericRespository<BookingOffice>
    {
        Task<PagedResult<BookingOffice>> GetAllRecords();
        Task<PagedResult<BookingOffice>> Find(GetPaggingRequest request);
    }
}
