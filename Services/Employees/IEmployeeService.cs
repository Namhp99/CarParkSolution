using Models.Entities;
using Models.View.Employees;
using Models.View.Pagging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Employees
{
    public interface IEmployeeService
    {
        Task<int> Create(EmployeeCreateRequest request );
        Task<int> Update(EmployeeUpdateRequest request);

        Task<int> Delete(int employeeId);
        Task<EmployeeView> GetById(int Id);
        Task<List<EmployeeView>> GetAll();
        Task<PagedResult<EmployeeView>> GetEmployeePaging(GetPaggingRequest request);
        Task<PagedResult<EmployeeView>> GetEmployeeByPhone(GetPaggingRequest request);
        Task<PagedResult<EmployeeView>> GetEmployeeByAddress(GetPaggingRequest request);
        Task<PagedResult<EmployeeView>> GetEmployeeByEmail(GetPaggingRequest request);

        Task<PagedResult<EmployeeView>> GetEmployeeByDepartment(GetPaggingRequest request);
    }
}
