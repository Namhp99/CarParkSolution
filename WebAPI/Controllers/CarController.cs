using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Models.Entities;
using Models.UnitofWorks;
using Models.View.Cars;
using Models.View.Pagging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "HRM, Admin")]

    public class CarController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CarController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] CarDTO request)
        {
            var car = _mapper.Map<Car>(request);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _unitOfWork.Cars.Create(car);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok();
        }      
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromForm] CarDTO request)
        {
            var car = _mapper.Map<Car>(request);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _unitOfWork.Cars.Update(car);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _unitOfWork.Cars.Delete(Id);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _unitOfWork.Cars.GetAll();
            //var result = await _carService.GetAll();
            if (result == null)
            {
                return BadRequest();
            }
            var car = _mapper.Map<IEnumerable<CarDTO>>(result);
            return Ok(car);
        }
        [HttpPost("GetInfo")]
        public async Task<IActionResult> GetByCar(string request)
        {
            var result = await _unitOfWork.Cars.GetByCar(request);
            if (result == null)
            {
                return BadRequest();
            }
            var car = _mapper.Map<CarDTO>(result);
            return Ok(car);
        }
        [HttpPost("GetPagging")]
        public async Task<IActionResult> GetPagging([FromForm] GetPaggingRequest request)
        {
            var result = await _unitOfWork.Cars.GetPaging(request);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpGet("GetAllRecords")]
        public async Task<IActionResult> GetAllRecords()
        {
            var result = await _unitOfWork.Cars.GetAllRecords();
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpPost("Find")]
        public async Task<IActionResult> Find([FromForm] GetPaggingRequest request)
        {
            var result = await _unitOfWork.Cars.Find(request);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
