using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDDSample1.Infrastructure;
using Domain.Patients;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Patients
{
    public class PatientRepository
    {
        private readonly DDDSample1DbContext _context;
        public PatientRepository(DDDSample1DbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();
        }
        public async Task<Patient> GetByIdAsync(int id)
        {
            return await _context.Patients.FindAsync(id);
        }
        public async Task<List<Patient>> GetAllAsync()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task<Patient> GetByEmailAsync(string email)
        {
            return await _context.Patients.FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());
        }

        public async Task<Patient> GetByPhoneNumberAsync(string phoneNumber)
        {
            return await _context.Patients.FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber);
        }

        public async Task<Patient> GetByMedicalRecordNumberAsync(int medicalRecordNumber)
        {
            return await _context.Patients.FirstOrDefaultAsync(x => x.MedicalRecordNumber == medicalRecordNumber);
        }
    }
}