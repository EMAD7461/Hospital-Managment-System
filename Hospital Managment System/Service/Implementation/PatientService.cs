using Hospital_Managment_System.Models;
using Hospital_Managment_System.Repositry.Implemntation;
using Hospital_Managment_System.Repositry.Interfaces;
using Hospital_Managment_System.Service.Interfaces;

namespace Hospital_Managment_System.Service.Implementation
{
    public class PatientService : IPatientService
    {
        private IPatientRepositry _PatientRepositry;
        public PatientService(IPatientRepositry PatientRepositry)
        { 
            _PatientRepositry = PatientRepositry;
        }
        public IEnumerable<Patient> GetAllPatients() => _PatientRepositry.GetAllPatients();

        public Patient GetPatientId(int id) => _PatientRepositry.GetPatientId(id);

        public void AddPatient(Patient patient)
        {
            _PatientRepositry.AddPatient(patient);
        }

        public void UpdatePatient(Patient patient)=> _PatientRepositry?.UpdatePatient(patient); 
        public void DeletePatient(int id)=>_PatientRepositry.DeletePatient(id);

    }
}
