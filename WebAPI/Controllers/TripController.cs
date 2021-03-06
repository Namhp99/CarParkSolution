using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Models.Entities;
using Models.UnitofWorks;
using Models.View.Pagging;
using Models.View.Trips;
using Services.InterfaceService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  //  [Authorize(Roles = "HRM, Admin")]

    public class TripController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITripService _tripService;

        public TripController(IMapper mapper, ITripService tripService)
        {
            _mapper = mapper;
            _tripService = tripService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] TripDTO request)
        {
            var trip = _mapper.Map<Trip>(request);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _tripService.Create(trip);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromForm] TicketUpdateDTO request)
        {
            var trip = _mapper.Map<Trip>(request);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _tripService.Update(trip);
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
            var result = await _tripService.Delete(Id);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _tripService.GetAll();
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpPost("GetInfo")]
        public async Task<IActionResult> GetById(int Id)
        {
            var result = await _tripService.GetById(Id);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpPost("GetPagging")]
        public async Task<IActionResult> GetPagging([FromForm] GetPaggingRequest request)
        {
            var result = await _tripService.GetPaging(request);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpGet("GetAllRecords")]
        public async Task<IActionResult> GetAllRecords()
        {
            var result = await _tripService.GetAllRecords();
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpPost("Find")]
        public async Task<IActionResult> Find([FromForm] GetPaggingRequest request)
        {
            var result = await _tripService.Find(request);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
