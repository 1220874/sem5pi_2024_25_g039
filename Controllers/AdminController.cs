using DDDSample1;
using DDDSample1.Infrastructure;
using Domain.Users;
using Infrastructure.Users;
using Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace DDDSample1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase{

        private readonly UserRepository _userRepository;
        
        private readonly UserService _userService;

        public AdminController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("Criar Back Office User")]
        public async Task<IActionResult> CreateUser([FromBody] UserDto user)
        {   try
            {
                if (!User.IsInRole(UserRole.Admin.ToString()))
                {
                    return Unauthorized(new { mensagem = "Você não é admin." });
                }


                if (user == null)
                {
                    return BadRequest("User data is null.");
                }

                // Adicionar validação de campos, se necessário
                if (string.IsNullOrEmpty(user.Username) )
                {
                    return BadRequest("Username are required.");
                }
                
                await _userService.AddAsync(user);
                return Ok("User created successfully.");
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
        }
    }
}
