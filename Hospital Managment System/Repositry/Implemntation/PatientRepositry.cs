using Hospital_Managment_System.Models;
using Hospital_Managment_System.Repositry.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Managment_System.Repositry.Implemntation
{
    public class PatientRepositry : IPatientRepositry
    {
        private HospitalDBContext _context;
        public PatientRepositry(HospitalDBContext context)
        {
            _context = context;
        }
         public IEnumerable<Patient> GetAllPatients()=> _context.Patients.ToList();

        public Patient GetPatientId(int id) => _context.Patients.FirstOrDefault(e => e.Id == id);

        public void AddPatient(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
        }

        public void UpdatePatient(Patient patient)
        {
            _context.Patients.Update(patient);
            _context.SaveChanges();
        }
        public void DeletePatient(int id)
        {
            var Patient = GetPatientId(id);
            if (Patient != null)
            {
                _context.Patients.Remove(Patient);
                _context.SaveChanges();
            }

        }
        
    }
}
