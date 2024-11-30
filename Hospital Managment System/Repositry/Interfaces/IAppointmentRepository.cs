using Hospital_Managment_System.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hospital_Managment_System.Repositry.Interfaces
{
    public interface IAppointmentRepository
    {
       public Task<IEnumerable<Appointment>> GetAllAppointmentAsync(); // Changed to async
       public Task<Appointment> GetAppointmentByIdAsync(int id); // Changed to async
       public Task AddAppointmentAsync(Appointment appointment); // Changed to async
       public Task UpdateAppointmentAsync(Appointment appointment); // Changed to async
        public Task DeleteAppointmentAsync(int id); // Changed to async
    }
}
