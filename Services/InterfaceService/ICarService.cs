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
        Task<Car> GetById(int id);
        Task<PagedResult<Car>> GetPaging(GetPaggingRequest request);
    }
}
