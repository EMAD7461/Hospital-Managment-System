using System.ComponentModel.DataAnnotations;

namespace Hospital_Managment_System.Models
{

    public class Doctor
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public string Speciality { get; set; }

        public Department Department { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
    }
}
