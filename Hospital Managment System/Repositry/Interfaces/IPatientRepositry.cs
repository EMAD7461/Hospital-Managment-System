using Hospital_Managment_System.Models;

namespace Hospital_Managment_System.Repositry.Interfaces
{
    public interface IPatientRepositry
    {
        public IEnumerable<Patient> GetAllPatients();

        public Patient GetPatientId(int id);

        public void AddPatient(Patient patient);

        public void UpdatePatient(Patient patient);
        public void DeletePatient(int id);
    }
}
