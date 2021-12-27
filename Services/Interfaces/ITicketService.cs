using Models.Entities;
using Models.View.Pagging;
using Models.View.Tickets;
using Models.View.Trips;
using Services.GenericRespository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ITicketService : IGenericRespository<Ticket>
    {
        Task<PagedResult<Ticket>> GetAllRecords();
        Task<PagedResult<Ticket>> Find(GetPaggingRequest request);

    }
}
