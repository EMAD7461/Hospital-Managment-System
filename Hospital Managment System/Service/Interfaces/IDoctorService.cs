using Hospital_Managment_System.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hospital_Managment_System.Service.Interfaces
{
    public interface IDoctorService
    {
      public Task<IEnumerable<Doctor>> GetAllDoctorsAsync(); // Ensure this is async
      public Task<Doctor> GetDoctorById(int id); // Ensure this is async
      public Task AddDoctor(Doctor doctor); // Ensure this is async
      public Task UpdateDoctor(Doctor doctor); // Ensure this is async
        public Task RemoveDoctor(int id); // Ensure this is async
    }
}
