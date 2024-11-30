using System.ComponentModel.DataAnnotations;

namespace Hospital_Managment_System.Models
{
    public class Nurse
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Gender { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public string Department { get; set; }
    }
}
