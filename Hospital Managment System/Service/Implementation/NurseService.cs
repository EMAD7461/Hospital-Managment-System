using Hospital_Managment_System.Models;
using Hospital_Managment_System.Repositry.Interfaces;
using Hospital_Managment_System.Service.Interfaces;
using System.Collections.Generic;

namespace Hospital_Managment_System.Service.Implementation
{
    public class NurseService : INurseService
    {
        private readonly INurseRepository _nurseRepository;

        public NurseService(INurseRepository nurseRepository)
        {
            _nurseRepository = nurseRepository;
        }

        public async Task<IEnumerable<Nurse>> GetAllNursesAsync()
        {
            return await _nurseRepository.GetAllNursesAsync();
        }
        public Nurse GetNurseById(int id) => _nurseRepository.GetNurseById(id);

        public void AddNurse(Nurse nurse) => _nurseRepository.AddNurse(nurse);

        public void UpdateNurse(Nurse nurse) => _nurseRepository.UpdateNurse(nurse);

        public void DeleteNurse(int id) => _nurseRepository.DeleteNurse(id);
    }
}