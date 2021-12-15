using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.View.BookOffices;
using Models.View.Pagging;
using Services.BookingOffices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookOfficeController : ControllerBase
    {
        private readonly IBookOfficeService _bookOfficeService;
        public BookOfficeController(IBookOfficeService bookOfficeService)
        {
            _bookOfficeService = bookOfficeService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateBookOffice([FromForm] BookCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _bookOfficeService.Create(request);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBookOffice([FromForm] BookUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _bookOfficeService.Update(request);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBookOffice(int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _bookOfficeService.Delete(Id);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOffice()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _bookOfficeService.GetAll();
            if (result == null)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpGet("/GetOffice/{Id}")]
        public async Task<IActionResult> GetOfficeById(int Id)
        {
            var result = await _bookOfficeService.GetById(Id);
            if (result == null)
            {
                return BadRequest("Khong tim thay phong");
            }
            return Ok(result);
        }
        [HttpPost("/GetOfficePagging")]
        public async Task<IActionResult> GetOfficePagging([FromForm] GetPaggingRequest request)
        {
            var result = await _bookOfficeService.GetOfficePaging(request);
            //if (result == null)
            //{
            //    return BadRequest("Khong tim thay nhan vien");
            //}
            return Ok(result);
        }
    }
}
