using Hospital_Managment_System.Models;
using Hospital_Managment_System.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Hospital_Managment_System.Controllers
{
    [Authorize(Roles = "Admin,Doctor,Patient")]
    public class PatientController : Controller
    {
        private IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }
        [HttpGet]
        public IActionResult Index()
        {
           
                var patients = _patientService.GetAllPatients();
                return View(patients);
           
        }
        public IActionResult Create()=>View();

        [HttpPost]
        public IActionResult Create(Patient patient)

        {
            if(ModelState.IsValid)
            { 
             _patientService.AddPatient(patient);
            return RedirectToAction("Index");
            }
            return View(patient);
        }
        public IActionResult Edit(int id)
        {
            var Patient = _patientService.GetPatientId(id);
            if (Patient == null)  return View("Not Found");
            return View(Patient);
        }

        [HttpPut]
        public IActionResult Edit(Patient Patient)
        {
            if (ModelState.IsValid)
            {
                _patientService.AddPatient(Patient);
                return RedirectToAction("Index");
            }
            return View(Patient);
        }

        public IActionResult Delete(int id)
        {
            var Patient =_patientService.GetPatientId(id);
            if (Patient == null) return View("Not Found");
            return View(Patient);
        }
        [HttpDelete, ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            _patientService.DeletePatient(id);
            return RedirectToAction("Index");
        }
    }
}
