using Models.Entities;
using Models.View.Pagging;
using Models.View.Parkinglots;
using Services.GenericRespository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IParkinglotService : IGenericRespository<Parkinglot>
    {
        Task<int> Create(ParkinglotCreateRequest request);
        Task<int> Update(ParkinglotUpdateRequest request); 
        Task<PagedResult<Parkinglot>> GetAllRecords();
        Task<PagedResult<Parkinglot>> Find(GetPaggingRequest request);

    }
}
