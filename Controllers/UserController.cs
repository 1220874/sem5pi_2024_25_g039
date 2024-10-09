using DDDSample1;
using Domain.Users;
using Infrastructure.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Services;

namespace DDDSample1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] UserLoginDto model)
        {
            try
            {
                var token = await _userService.AuthenticateAsync(model.Username, model.Password);

                if (token == null){
                    return BadRequest(new { message = "Email ou password incorreto." });    
                }
            
                return Ok(new{Token = token});
            }
            catch (Exception e)
            {
                return BadRequest(new { e.Message });
            }
        }
    }
}
