
namespace Domain.Patients
{
    public class EditPatientDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string MedicalHistory { get; set; }
        public string Allergies { get; set; }

        public EditPatientDto(string firstName, string lastName, string phoneNumber, string medicalHistory, string allergies)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            MedicalHistory = medicalHistory;
            Allergies = allergies;
        }
    }

}