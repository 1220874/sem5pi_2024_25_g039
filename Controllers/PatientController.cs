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

        [HttpGet]
        [Route("GetPatientByEmail")]
        public async Task<IActionResult> GetPatientByEmail(string email)
        {
            try
            {
                if (!User.IsInRole(UserRole.Admin.ToString()))
                {
                    return Unauthorized(new { mensagem = "Não tens autorizações admin." });
                }

                var patient = await _patientService.GetByEmailAsync(email);
                if (patient == null)
                {
                    return NotFound("Paciente não encontrado.");
                }

                return Ok(patient);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Erro interno do servidor: {e.Message}");
            }
        }



        [HttpPost]
        [Route("EditPatientProfile")]
        public async Task<IActionResult> EditPatientProfile(string email, [FromBody] EditPatientDto editPatientDto)
        {
            try
            {
                if (!User.IsInRole(UserRole.Admin.ToString()))
                {
                    return Unauthorized(new { mensagem = "Não tens autorizações admin." });
                }

                if (editPatientDto == null)
                {
                    return BadRequest("Os dados do paciente são nulos.");
                }

                await _patientService.EditAsync(email, editPatientDto);
                return Ok("Paciente editado com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Erro interno do servidor: {e.Message}");
            }
        }

        private EditPatientDto ConvertToEditPatientDto(PatientDto patientDto)
        {
            return new EditPatientDto(
                patientDto.FirstName,
                patientDto.LastName,
                patientDto.PhoneNumber,
                patientDto.Email,
                patientDto.MedicalHistory,
                patientDto.Allergies
            );
        }

    }
}