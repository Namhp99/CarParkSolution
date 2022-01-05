using Models.Entities;
using Models.Repository.Interfaces;
using Models.UnitofWorks;
using Models.View.Pagging;
using Services.InterfaceService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.ImplementService
{
    public class EmployeeService : IEmployeeService
    {
        IEmployeeRepository _employeeRepository;
        IUnitOfWork _unitOfWork;
        public EmployeeService(IEmployeeRepository employeeService, IUnitOfWork unitOfWork)
        {
            _employeeRepository = employeeService;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Create(Employee request)
        {
            var result = await _employeeRepository.Create(request);
            return result;
        }

        public async Task<int> Delete(int id)
        {
            return await _employeeRepository.Delete(id);
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _employeeRepository.GetAll();
        }

        public async Task<Employee> GetById(int id)
        {
            return await _employeeRepository.GetById(id);
        }

        public async Task<PagedResult<Employee>> GetPaging(GetPaggingRequest request)
        {
            return await _employeeRepository.GetPaging(request);
        }

        public async Task<int> Update(Employee request)
        {
            return await _employeeRepository.Update(request);
        }
    }
}
