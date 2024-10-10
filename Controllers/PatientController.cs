using System;
using System.Threading.Tasks;
using Domain.Patients;
using Domain.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly PatientService _patientService;
        

        public PatientController(PatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpPost]
        [Route("CreatePatientProfile")]
        public async Task<IActionResult> CreatePatientProfile(PatientDto patientDto)
        {
            try
            {
                if (!User.IsInRole(UserRole.Admin.ToString()))
                {
                    return Unauthorized(new { mensagem = "Não tens autorizações admin." });
                }

                if (patientDto == null)
                {
                    return BadRequest("Patient data is null.");
                }
                
                await _patientService.AddAsync(patientDto);
                return Ok("Patient created successfully.");
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
        }
    }
}