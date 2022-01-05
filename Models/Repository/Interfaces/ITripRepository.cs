using Models.Entities;
using Models.GenericRepository;
using Models.View.Pagging;
using Models.View.Trips;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repository.Interfaces
{
    public interface ITripRepository : IGenericRepository<Trip>
    {
        Task<PagedResult<Trip>> GetAllRecords();
        Task<PagedResult<Trip>> Find(GetPaggingRequest request);

    }
}
