using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.EF;
using Models.Entities;
using Models.Repository.Interfaces;
using Models.UnitofWorks;
using Moq;
using Services.ImplementService;
using Services.InterfaceService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.ServiceTest
{
    [TestClass]
    public class EmployeeTest
    {

        private Mock<IEmployeeRepository> _mockRepository;
        private Mock<IUnitOfWork> _mockUnit;
        private IEmployeeService _employeeService;
        private List<Employee> list;
        [TestInitialize]
        public void Initialize()
        {
            _mockUnit = new Mock<IUnitOfWork>();
            _mockRepository = new Mock<IEmployeeRepository>();
            _employeeService = new EmployeeService(_mockRepository.Object, _mockUnit.Object);
            list = new List<Employee>()
            {
                new Employee() {EmployeeId = 1, EmployeeAddress = "Test1" },
                new Employee() {EmployeeId = 2, EmployeeAddress = "Test12" },
                new Employee() {EmployeeId = 3, EmployeeAddress = "Test13" }
            };
        }
        [TestMethod]
        public void GetAllTest()
        {
            _mockRepository.Setup(m => m.GetAll()).ReturnsAsync(list.AsEnumerable());
            var result = _employeeService.GetAll().Result;
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void GetInfoTest()
        {
            Employee employee = new Employee();
            int id = 1;
            employee.EmployeeId = 1;
            employee.EmployeeEmail = "Test1";
            employee.EmployeeAddress = "Test2";
            _mockRepository.Setup(m => m.GetById(It.IsAny<int>())).ReturnsAsync(employee);
            var result = _employeeService.GetById(id).Result;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreateTest()
        {
            Employee employee = new Employee();
            int id = 1;
            employee.EmployeeEmail = "Test1";
            employee.EmployeeAddress = "Test2";
            _mockRepository.Setup(m => m.Create(employee)).ReturnsAsync(id);           
            var result = _employeeService.Create(employee);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
        }
    }
}
