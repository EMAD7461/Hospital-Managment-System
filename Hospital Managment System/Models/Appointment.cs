using System;
using System.ComponentModel.DataAnnotations;

namespace Hospital_Managment_System.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        // Navigation property for Doctor
        public Doctor Doctor { get; set; }

      
        public int? DoctorId { get; set; }  // Nullable to allow no immediate selection

        // Navigation property for Patient
        public Patient Patient { get; set; }

        [Required(ErrorMessage = "Patient Name is required.")]
        public string PatientName { get; set; }

        // Foreign key for Patient
        public int? PatientId { get; set; }  // Nullable

        // Navigation property for Nurse
        public Nurse Nurse { get; set; }

        
        public int? NurseId { get; set; }  // Nullable

        [Required(ErrorMessage = "Appointment Date is required.")]
        [DataType(DataType.Date)]
        public DateTime AppointmentDate { get; set; }

        [Required(ErrorMessage = "Speciality is required.")]
        public string Speciality { get; set; }  // Specify the required field for speciality

        [Required(ErrorMessage = "Status is required.")]
        public string Status { get; set; }  // Scheduled, Completed, Cancelled
    }
}
