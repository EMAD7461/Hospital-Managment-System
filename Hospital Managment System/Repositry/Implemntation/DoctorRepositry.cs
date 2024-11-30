using Hospital_Managment_System.Models;
using Hospital_Managment_System.Repositry.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hospital_Managment_System.Repositry.Implemntation
{
    public class DoctorRepositry : IDoctorRepositry
    {
        private readonly HospitalDBContext _context;

        public DoctorRepositry(HospitalDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync()
        {
            return await _context.Doctors.ToListAsync(); // Using Entity Framework's ToListAsync
        }

        public async Task<Doctor> GetDoctorByIdAsync(int id)
        {
            return await _context.Doctors.FindAsync(id); // Using Entity Framework's FindAsync
        }

        public async Task AddDoctorAsync(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor); // Using Entity Framework's AddAsync
            await _context.SaveChangesAsync(); // Save changes asynchronously
        }

        public async Task UpdateDoctorAsync(Doctor doctor)
        {
            _context.Doctors.Update(doctor); // Update the doctor
            await _context.SaveChangesAsync(); // Save changes asynchronously
        }

        public async Task RemoveDoctorAsync(int id)
        {
            var doctor = await GetDoctorByIdAsync(id); // Retrieve the doctor to delete
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor); // Remove the doctor
                await _context.SaveChangesAsync(); // Save changes asynchronously
            }
        }
    }
}
