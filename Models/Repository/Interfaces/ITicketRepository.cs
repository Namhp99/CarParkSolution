using Models.Entities;
using Models.GenericRepository;
using Models.View.Pagging;
using Models.View.Tickets;
using Models.View.Trips;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repository.Interfaces
{
    public interface ITicketRepository : IGenericRepository<Ticket>
    {
        Task<PagedResult<Ticket>> GetAllRecords();
        Task<PagedResult<Ticket>> Find(GetPaggingRequest request);

    }
}
