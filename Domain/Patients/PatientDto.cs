using System;

namespace Domain.Patients
{
    public class PatientDto
    {
        //public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int MedicalRecordNumber { get; set; }
        public string Address { get; set; }
        public string EmergencyContact { get; set; }
        public string AppointmentHistory { get; set; }

        public PatientDto(string firstName, string lastName, DateTime birthDate, string gender, string email, string phoneNumber, int medicalRecordNumber, string address, string emergencyContact, string appointmentHistory)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Gender = gender;
            Email = email;
            PhoneNumber = phoneNumber;
            MedicalRecordNumber = medicalRecordNumber;
            Address = address;
            EmergencyContact = emergencyContact;
            AppointmentHistory = appointmentHistory;
        }

    }
}