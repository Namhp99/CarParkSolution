using Models.Entities;
using Models.View.Employees;
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
        Task<PagedResult<EmployeeView>> GetEmployeePaging(GetEmployeePaggingRequest request);
        Task<PagedResult<EmployeeView>> GetEmployeeByPhone(GetEmployeePaggingRequest request);
        Task<PagedResult<EmployeeView>> GetEmployeeByAddress(GetEmployeePaggingRequest request);
        Task<PagedResult<EmployeeView>> GetEmployeeByEmail(GetEmployeePaggingRequest request);

        Task<PagedResult<EmployeeView>> GetEmployeeByDepartment(GetEmployeePaggingRequest request);
    }
}
