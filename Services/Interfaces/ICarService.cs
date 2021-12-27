using Models.Entities;
using Models.View.Cars;
using Models.View.Pagging;
using Services.GenericRespository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICarService : IGenericRespository<Car>
    {
        Task<PagedResult<Car>> GetAllRecords();       
        Task<PagedResult<Car>> Find(GetPaggingRequest request);
        Task<Car> GetByCar(string request);
    }
}
