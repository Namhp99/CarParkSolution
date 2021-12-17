using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.View.Pagging;
using Models.View.Trips;
using Services.Trips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {

        private readonly ITripService _tripService;
        public TripController(ITripService tripService)
        {
            _tripService = tripService;
        }
        [HttpPost("/AddTrip")]
        public async Task<IActionResult> CreateTrip([FromForm] TripCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _tripService.Create(request);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpPut("/UpdateTrip")]
        public async Task<IActionResult> UpdateTrip([FromForm] TripUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _tripService.Update(request);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpDelete("/DelTrip")]
        public async Task<IActionResult> DeleteTrip(int Id)
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
        [HttpGet("/GetAllTrip")]
        public async Task<IActionResult> GetAllTrip()
        {
            var result = await _tripService.GetAll();
            //if (result.Count == 0)
            //{
            //    return BadRequest();
            //}
            return Ok(result);
        }
        [HttpGet("/GetTripInfo")]
        public async Task<IActionResult> GetTripById(int Id)
        {
            var result = await _tripService.GetById(Id);
            if (result == null)
            {
                return BadRequest("Khong tim thay chuyen");
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
