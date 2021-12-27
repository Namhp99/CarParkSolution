using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.View.Pagging;
using Models.View.Parkinglots;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "HRM, Admin")]
    public class ParkinglotController : ControllerBase
    {
        private readonly IParkinglotService _parkinglotService;
        public ParkinglotController(IParkinglotService parkinglotService)
        {
            _parkinglotService = parkinglotService;
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] ParkinglotCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _parkinglotService.Create(request);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromForm] ParkinglotUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _parkinglotService.Update(request);
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
            var result = await _parkinglotService.Delete(Id);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _parkinglotService.GetAll();
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpPost("GetInfo")]
        public async Task<IActionResult> GetById(int Id)
        {
            var result = await _parkinglotService.GetById(Id);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpPost("GetPagging")]
        public async Task<IActionResult> GetPagging([FromForm] GetPaggingRequest request)
        {
            var result = await _parkinglotService.GetPaging(request);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpGet("GetAllRecords")]
        public async Task<IActionResult> GetAllRecords()
        {
            var result = await _parkinglotService.GetAllRecords();
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpPost("Find")]
        public async Task<IActionResult> Find([FromForm] GetPaggingRequest request)
        {
            var result = await _parkinglotService.Find(request);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
