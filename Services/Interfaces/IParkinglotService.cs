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
    public interface IParkinglotService : IGenericRepository<Parkinglot>
    {
        Task<PagedResult<Parkinglot>> GetAllRecords();
        Task<PagedResult<Parkinglot>> Find(GetPaggingRequest request);

    }
}
