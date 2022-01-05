using Models.Entities;
using Models.View.Pagging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.InterfaceService
{
    public interface IBookingOfficeService
    {
        Task<int> Create(BookingOffice request);
        Task<int> Update(BookingOffice request);
        Task<int> Delete(int id);
        Task<IEnumerable<BookingOffice>> GetAll();
        Task<BookingOffice> GetById(int id);
        Task<PagedResult<Car>> GetPaging(GetPaggingRequest request);
    }
}
