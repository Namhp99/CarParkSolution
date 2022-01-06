using Models.Entities;
using Models.View.Pagging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.InterfaceService
{
    public interface ITicketService
    {
        Task<int> Create(Ticket request);
        Task<int> Update(Ticket request);
        Task<int> Delete(int id);
        Task<IEnumerable<Ticket>> GetAll();
        Task<Ticket> GetById(int id);
        Task<PagedResult<Ticket>> GetPaging(GetPaggingRequest request);
        Task<PagedResult<Ticket>> GetAllRecords();
        Task<PagedResult<Ticket>> Find(GetPaggingRequest request);
    }
}
