using Models.View.Pagging;
using Models.View.Parkinglots;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Parkinglots
{
    public interface IParkinglotService
    {
        Task<int> Create(ParkinglotCreateRequest request);
        Task<int> Update(ParkinglotUpdateRequest request);

        Task<int> Delete(int Id);
        Task<ParkinglotView> GetById(int Id);
        Task<List<ParkinglotView>> GetAll();
        Task<PagedResult<ParkinglotView>> GetParkinglotPaging(GetPaggingRequest request);
    }
}
