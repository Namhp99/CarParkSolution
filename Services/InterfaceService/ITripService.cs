using Models.Entities;
using Models.View.Pagging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.InterfaceService
{
    public interface ITripService
    {
        Task<int> Create(Trip request);
        Task<int> Update(Trip request);
        Task<int> Delete(int id);
        Task<IEnumerable<Trip>> GetAll();
        Task<Trip> GetById(int id);
        Task<PagedResult<Trip>> GetPaging(GetPaggingRequest request);
    }
}
