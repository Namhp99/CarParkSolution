using Models.Entities;
using Models.GenericRepository;
using Models.View.Pagging;
using Models.View.Parkinglots;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repository.Interfaces
{
    public interface IParkinglotRepository : IGenericRepository<Parkinglot>
    {
        Task<PagedResult<Parkinglot>> GetAllRecords();
        Task<PagedResult<Parkinglot>> Find(GetPaggingRequest request);

    }
}
