using Models.View.BookOffices;
using Models.View.Pagging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.BookingOffices
{
    public interface IBookOfficeService
    {
        Task<int> Create(BookCreateRequest request);
        Task<int> Update(BookUpdateRequest request);

        Task<int> Delete(int employeeId);
        Task<BookView> GetById(int Id);
        Task<List<BookView>> GetAll();
        Task<PagedResult<BookView>> GetOfficePaging(GetPaggingRequest request);
    }
}
