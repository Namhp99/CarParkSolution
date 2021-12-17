using Models.View.Pagging;
using Models.View.Trips;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Trips
{
    public interface ITripService
    {
        Task<int> Create(TripCreateRequest request);
        Task<int> Update(TripUpdateRequest request);

        Task<int> Delete(int Id);
        Task<TripView> GetById(int Id);
        Task<List<TripView>> GetAll();
        Task<PagedResult<TripView>> GetTripPagging(GetPaggingRequest request);
    }
}
