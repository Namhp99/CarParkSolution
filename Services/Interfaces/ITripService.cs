using Models.Entities;
using Models.View.Pagging;
using Models.View.Trips;
using Services.GenericRespository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ITripService : IGenericRespository<Trip>
    {
        Task<int> Create(TripCreateRequest request);
        Task<int> Update(TripUpdateRequest request);
        Task<PagedResult<Trip>> GetAllRecords();
        Task<PagedResult<Trip>> Find(GetPaggingRequest request);

    }
}
