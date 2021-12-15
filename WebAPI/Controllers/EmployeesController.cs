using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.View.Employees;
using Models.View.Pagging;
using Services.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromForm] EmployeeCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _employeeService.Create(request);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromForm] EmployeeUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _employeeService.Update(request);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteEmployee(int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _employeeService.Delete(Id);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpGet("/AllEmployee")]
        public async Task<IActionResult> GetAllEmployee()
        {

            var result = await _employeeService.GetAll();
            if (result.Count == 0)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpGet("/GetEmployee/{Id}")]
        public async Task<IActionResult> GetEmployeeById(int Id)
        {
            var result = await _employeeService.GetById(Id);
            if (result == null)
            {
                return BadRequest("Khong tim thay nhan vien");
            }
            return Ok(result);
        }
        [HttpPost("/GetEmployeePagging")]
        public async Task<IActionResult> GetEmployeePagging([FromForm] GetPaggingRequest request)
        {
            var result = await _employeeService.GetEmployeePaging(request);
            //if (result == null)
            //{
            //    return BadRequest("Khong tim thay nhan vien");
            //}
            return Ok(result);
        }
    }
}
