using Hospital_Managment_System.Models;
using Hospital_Managment_System.Repositry.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Hospital_Managment_System.Repositry.Implemntation
{
    public class NurseRepository : INurseRepository
    {
        private readonly HospitalDBContext _context;

        public NurseRepository(HospitalDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Nurse>> GetAllNursesAsync()
        {
            return await _context.Nurses.ToListAsync(); // Fetching all nurses asynchronously
        }
        public Nurse GetNurseById(int id) => _context.Nurses.FirstOrDefault(n => n.Id == id);

        public void AddNurse(Nurse nurse)
        {
            _context.Nurses.Add(nurse);
            _context.SaveChanges();
        }

        public void UpdateNurse(Nurse nurse)
        {
            _context.Nurses.Update(nurse);
            _context.SaveChanges();
        }

        public void DeleteNurse(int id)
        {
            var nurse = GetNurseById(id);
            if (nurse != null)
            {
                _context.Nurses.Remove(nurse);
                _context.SaveChanges();
            }
        }
    }
}