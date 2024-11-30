using System.ComponentModel.DataAnnotations;

namespace Hospital_Managment_System.Models
{
    public class Patient
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }
        [Required]
        [RegularExpression(@"Male|Female")]
        public string Gender { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        List<Appointment> Appointments { get; set; }
    }
}
