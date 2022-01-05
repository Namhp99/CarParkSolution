using Models.Entities;
using Models.Repository.Interfaces;
using Models.UnitofWorks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface ITest 
    {
        Task<IEnumerable<Employee>> GetAll();
    }
    public class Test : ITest
    {
        IEmployeeRepository _employeeRepository;
        IUnitOfWork _unitOfWork;
        public Test(IEmployeeRepository employeeService, IUnitOfWork unitOfWork)
        {
            _employeeRepository = employeeService;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Employee>> GetAll()
        {
            //return _employeeService.GetAll();
            return await _employeeRepository.GetAll();
        }
    }
}
