using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.View.Parkinglots;
using Services.Parkinglots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkinglotController : ControllerBase
    {
        private readonly IParkinglotService _parkinglotService;
        public ParkinglotController(IParkinglotService parkinglotService)
        {
            _parkinglotService = parkinglotService;
        }
        [HttpPost("/AddParkinglot")]
        public async Task<IActionResult> CreateParkinglot([FromForm] ParkinglotCreateRequest request)
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
        [HttpPut("/UpdateParkinglot")]
        public async Task<IActionResult> UpdateParkinglot([FromForm] ParkinglotUpdateRequest request)
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
        [HttpDelete("/DelParkinglot")]
        public async Task<IActionResult> DeleteParkinglot(int Id)
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
        [HttpGet("/GetAllParkinglot")]
        public async Task<IActionResult> GetAllParkinglot()
        {
            var result = await _parkinglotService.GetAll();
            //if (result.Count == 0)
            //{
            //    return BadRequest();
            //}
            return Ok(result);
        }
        [HttpGet("/GetParkinglotInfo")]
        public async Task<IActionResult> GetParkinglotById(int Id)
        {
            var result = await _parkinglotService.GetById(Id);
            if (result == null)
            {
                return BadRequest("Khong tim thay bai dau xe");
            }
            return Ok(result);
        }
        //[HttpPost("/GetTripPagging")]
        //public async Task<IActionResult> GetEmployeePagging([FromForm] GetPaggingRequest request)
        //{
        //    var result = await _tripService.GetTripPagging(request);
        //    //if (result == null)
        //    //{
        //    //    return BadRequest("Khong tim thay nhan vien");
        //    //}
        //    return Ok(result);
        //}
    }
}
