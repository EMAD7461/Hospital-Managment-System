using Hospital_Managment_System.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hospital_Managment_System.Repositry.Interfaces
{
    public interface IDoctorRepositry
    {
        Task<IEnumerable<Doctor>> GetAllDoctorsAsync(); // Changed to async
        Task<Doctor> GetDoctorByIdAsync(int id); // Changed to async
        Task AddDoctorAsync(Doctor doctor); // Changed to async
        Task UpdateDoctorAsync(Doctor doctor); // Changed to async
        Task RemoveDoctorAsync(int id); // Changed to async
    }
}
