using Hospital_Managment_System.Models;
using System.Collections.Generic;

namespace Hospital_Managment_System.Service.Interfaces
{
    public interface INurseService
    {
        Task<IEnumerable<Nurse>> GetAllNursesAsync();
        Nurse GetNurseById(int id);
        void AddNurse(Nurse nurse);
        void UpdateNurse(Nurse nurse);
        void DeleteNurse(int id);
    }
}