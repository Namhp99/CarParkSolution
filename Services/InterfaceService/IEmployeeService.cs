using Models.Entities;
using Models.View.Pagging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.InterfaceService
{
    public interface IEmployeeService
    {
        Task<int> Create(Employee request);
        Task<int> Update(Employee request);
        Task<int> Delete(int id);
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> GetById(int id);
        Task<PagedResult<Employee>> GetPaging(GetPaggingRequest request);
        Task<PagedResult<Employee>> Find(GetPaggingRequest request);

    }
}
