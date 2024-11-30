using Hospital_Managment_System.Models;
using System.Collections.Generic;

namespace Hospital_Managment_System.ViewModels
{
    public class AppointmentViewModel
    {
        public Appointment Appointment { get; set; }
        public IEnumerable<Doctor> Doctors { get; set; }
        public IEnumerable<Nurse> Nurses { get; set; }
    }
}
