using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.View.Cars;
using Models.View.Pagging;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        public CarController(ICarService carService)
        {
            _carService = carService;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] CarCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _carService.Create(request);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromForm] CarUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _carService.Update(request);
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
            var result = await _carService.Delete(Id);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _carService.GetAll();
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpPost("GetInfo")]
        public async Task<IActionResult> GetById(int Id)
        {
            var result = await _carService.GetById(Id);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpPost("GetPagging")]
        public async Task<IActionResult> GetPagging([FromForm] GetPaggingRequest request)
        {
            var result = await _carService.GetPaging(request);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpGet("GetAllRecords")]
        public async Task<IActionResult> GetAllRecords()
        {
            var result = await _carService.GetAllRecords();
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpPost("Find")]
        public async Task<IActionResult> Find([FromForm] GetPaggingRequest request)
        {
            var result = await _carService.Find(request);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
