using Hospital_Managment_System.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hospital_Managment_System.Service.Interfaces
{
    public interface IAppointmentService
    {
      public Task<IEnumerable<Appointment>> GetAllAppointment();
      public Task<Appointment> GetAppointmentById(int id);
      public Task AddAppointment(Appointment appointment);
      public Task UpdateAppointment(Appointment appointment);
      public Task DeleteAppointment(int id);
        public Task<bool> HasCompletedAppointments(int? patientId); // Updated to return Task<bool>
    }
}
