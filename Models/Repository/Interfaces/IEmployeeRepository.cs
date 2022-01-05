using Models.Entities;
using Models.GenericRepository;
using Models.View.Employees;
using Models.View.Pagging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repository.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<PagedResult<Employee>> Find(GetPaggingRequest request);

    }
}
