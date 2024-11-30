using Hospital_Managment_System.Models;
using Hospital_Managment_System.Repositry.Implemntation;
using Hospital_Managment_System.Repositry.Interfaces;
using Hospital_Managment_System.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hospital_Managment_System.Service.Implementation
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepositry _doctorRepository;

        public DoctorService(IDoctorRepositry doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync()
        {
            return await _doctorRepository.GetAllDoctorsAsync(); // Assume this is an async method
        }

        public async Task<Doctor> GetDoctorById(int id)
        {
            return await _doctorRepository.GetDoctorByIdAsync(id); // Assume this is an async method
        }

        public async Task AddDoctor(Doctor doctor)
        {
            await _doctorRepository.AddDoctorAsync(doctor); // Assume this is an async method
        }

        public async Task UpdateDoctor(Doctor doctor)
        {
            await _doctorRepository.UpdateDoctorAsync(doctor); // Assume this is an async method
        }

        public async Task RemoveDoctor(int id)
        {
            await _doctorRepository.RemoveDoctorAsync(id); // Assume this is an async method
        }
    }
}
