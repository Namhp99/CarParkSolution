using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Authentication;
using Models.View.Users;
using Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "HRM")]

    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Create([FromForm] LoginModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _userService.Login(request);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpPost("Register-HRM")]
        public async Task<IActionResult> RegisterHRM([FromForm] RegisterModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _userService.RegisterHRM(request);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
        [HttpPost("Register-Admin")]
        public async Task<IActionResult> RegisterAdmin([FromForm] RegisterModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _userService.RegisterAdmin(request);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
