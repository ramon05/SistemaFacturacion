using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaFacturacionApi.BI.Dtos;
using SistemaFacturacionApi.Model.Entities;
using SistemaFacturacionApi.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaFacturacionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<User, UserDto>
    {
        private readonly IUserService _userService;
        public UserController(IUserService service) : base(service)
        {
            _userService = service;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticateRequestDto model)
        {
            var response = await _userService.GetToken(model);

            if (response is null)
                return BadRequest(new { message = "User or Password is incorrect" });

            return Ok(response);
        }

        [HttpPost("changePassword/{userId}")]
        public async Task<IActionResult> ChangePassword([FromRoute] int userId, [FromBody] ChangePasswordDto model)
        {
            var response = await _userService.ChangePassword(userId, model);

            if (response.IsSuccess is false)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPost]
        [AllowAnonymous]
        public override async Task<IActionResult> Post([FromBody] UserDto dto)
        {
            return await base.Post(dto);
        }
    }
}
