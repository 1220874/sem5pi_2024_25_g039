
namespace Domain.Patients
{
    public class EditPatientDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string MedicalHistory { get; set; }
        public string Allergies { get; set; }

        public EditPatientDto(string firstName, string lastName, string phoneNumber, string email, string medicalHistory, string allergies)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            MedicalHistory = medicalHistory;
            Allergies = allergies;
        }
    }

}