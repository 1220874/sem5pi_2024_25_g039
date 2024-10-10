using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DDDSample1.Domain.Shared;
using Domain.Patients;
using Infrastructure.Patients;

namespace Services
{
    public class PatientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PatientRepository _repo;

        public PatientService(IUnitOfWork unitOfWork, PatientRepository repo)
        {
            this._unitOfWork = unitOfWork;
            this._repo = repo;
        }

        public PatientService() { }

        public async Task<List<PatientDto>> GetAllAsync()
        {
            var list = await this._repo.GetAllAsync();
            List<PatientDto> listDto = list.ConvertAll<PatientDto>(urs => new PatientDto(urs.FirstName, urs.LastName, urs.BirthDate, urs.Gender, urs.Email, urs.PhoneNumber, urs.MedicalRecordNumber, urs.Address, urs.EmergencyContact, urs.AppointmentHistory, urs.MedicalHistory, urs.Allergies));
            return listDto;
        }

        public async Task<PatientDto> GetByIdAsync(int id)
        {
            var urs = await this._repo.GetByIdAsync(id);
            if (urs == null)
                return null;
            return new PatientDto(urs.FirstName, urs.LastName, urs.BirthDate, urs.Gender, urs.Email, urs.PhoneNumber, urs.MedicalRecordNumber, urs.Address, urs.EmergencyContact, urs.AppointmentHistory, urs.MedicalHistory, urs.Allergies);
        }

        public async Task<PatientDto> AddAsync(PatientDto dto)
        {
            // Verificar se o email já existe no banco de dados
            var existingPatient = await this._repo.GetByEmailAsync(dto.Email);
            if (existingPatient != null)
            {
                throw new Exception("Email já registado no sistema.");
            }

            // Validar formato do email usando regex
            string emailPattern = @"^[\w.-]+@[a-zA-Z\d.-]+\.[a-zA-Z]{2,}$";
            if (!Regex.IsMatch(dto.Email, emailPattern))
            {
                throw new Exception("Formato de email inválido. (Exemplo: aaa@aaa.aaa)");
            }

            // Validar formato do número de telefone usando regex

            /* string phonePattern = @"^(\+351)?9[1236]\d{7}$";
            if (!Regex.IsMatch(dto.PhoneNumber, phonePattern))
            {
                throw new Exception("Formato de número de telefone inválido. (Exemplo: 912345678)");
            } */

            // Verificar se o numero de telefone existe
            var existingNumber = await this._repo.GetByPhoneNumberAsync(dto.PhoneNumber);
            if (existingNumber != null)
            {
                throw new Exception("Número de telefone já registado no sistema.");
            }

            // Verificar se o número de record clínico já existe
            var existingRecord = await this._repo.GetByMedicalRecordNumberAsync(dto.MedicalRecordNumber);
            if (existingRecord != null)
            {
                throw new Exception("Número de record clínico já registado no sistema.");
            }


            var patient = new Patient(dto.FirstName, dto.LastName, dto.BirthDate, dto.Gender, dto.Email, dto.PhoneNumber, dto.MedicalRecordNumber, dto.Address, dto.EmergencyContact, dto.AppointmentHistory, dto.MedicalHistory, dto.Allergies);
            await this._repo.AddAsync(patient);
            await this._unitOfWork.CommitAsync();
            return new PatientDto(patient.FirstName, patient.LastName, patient.BirthDate, patient.Gender, patient.Email, patient.PhoneNumber, patient.MedicalRecordNumber, patient.Address, patient.EmergencyContact, patient.AppointmentHistory, patient.MedicalHistory, patient.Allergies);
        }

        public async Task<PatientDto> GetByEmailAsync(string email)
        {
            var urs = await this._repo.GetByEmailAsync(email);
            if (urs == null)
                return null;
            return new PatientDto(urs.FirstName, urs.LastName, urs.BirthDate, urs.Gender, urs.Email, urs.PhoneNumber, urs.MedicalRecordNumber, urs.Address, urs.EmergencyContact, urs.AppointmentHistory, urs.MedicalHistory, urs.Allergies);
        }


        public async Task<PatientDto> EditAsync(string email, EditPatientDto dto)
        {
            var existingPatient = await this._repo.GetByEmailAsync(email);
            if (existingPatient == null)
            {
                throw new Exception("Paciente não encontrado.");
            }

            // Atualiza apenas os campos editáveis que foram fornecidos
            if (!string.IsNullOrWhiteSpace(dto.FirstName))
            {
                existingPatient.FirstName = dto.FirstName;
            }

            if (!string.IsNullOrWhiteSpace(dto.LastName))
            {
                existingPatient.LastName = dto.LastName;
            }

            if (!string.IsNullOrWhiteSpace(dto.PhoneNumber))
            {
                existingPatient.PhoneNumber = dto.PhoneNumber;
            }

            if (!string.IsNullOrWhiteSpace(dto.MedicalHistory))
            {
                existingPatient.MedicalHistory = dto.MedicalHistory;
            }

            if (!string.IsNullOrWhiteSpace(dto.Allergies))
            {
                existingPatient.Allergies = dto.Allergies;
            }

            // Salva o paciente atualizado
            await this._repo.UpdateAsync(existingPatient);

            // Retorna o paciente atualizado como PatientDto
            return new PatientDto(
                existingPatient.FirstName,
                existingPatient.LastName,
                existingPatient.BirthDate,
                existingPatient.Gender,
                existingPatient.Email,
                existingPatient.PhoneNumber,
                existingPatient.MedicalRecordNumber,
                existingPatient.Address,
                existingPatient.EmergencyContact,
                existingPatient.AppointmentHistory,
                existingPatient.MedicalHistory,
                existingPatient.Allergies
            );
        }


    }
}
