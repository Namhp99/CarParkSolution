using Models.Entities;
using Models.GenericRepository;
using Models.View.Cars;
using Models.View.Pagging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repository.Interfaces
{
    public interface ICarRepository : IGenericRepository<Car>
    {
        Task<PagedResult<Car>> GetAllRecords();       
        Task<PagedResult<Car>> Find(GetPaggingRequest request);
        Task<Car> GetByCar(string request);
    }
}
