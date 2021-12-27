using Models.Entities;
using Models.View.Employees;
using Models.View.Pagging;
using Services.GenericRespository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IEmployeeService : IGenericRespository<Employee>
    {
        Task<PagedResult<Employee>> Find(GetPaggingRequest request);

    }
}
