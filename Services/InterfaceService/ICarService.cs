using Models.Entities;
using Models.View.Pagging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.InterfaceService
{
    public interface ICarService
    {
        Task<int> Create(Car request);
        Task<int> Update(Car request);
        Task<int> Delete(int id);
        Task<IEnumerable<Car>> GetAll();
        Task<PagedResult<Car>> GetPaging(GetPaggingRequest request);
        Task<PagedResult<Car>> GetAllRecords();
        Task<PagedResult<Car>> Find(GetPaggingRequest request);
        Task<Car> GetByCar(string request);
    }
}
