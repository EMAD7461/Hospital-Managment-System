using Hospital_Managment_System.Models;
using Hospital_Managment_System.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hospital_Managment_System.Controllers
{
    [Authorize(Policy = "AdminOrDoctorPolicy")]
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var doctors = await _doctorService.GetAllDoctorsAsync(); // Assuming GetAllDoctors is async
            return View(doctors);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                await _doctorService.AddDoctor(doctor); // Assuming AddDoctor is async
                return RedirectToAction("Index");
            }
            return View(doctor);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var doctor = await _doctorService.GetDoctorById(id); // Assuming GetDoctorById is async
            return View(doctor);
        }

        [HttpPost] // Change to HttpPost for form submission
        public async Task<IActionResult> Edit(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                await _doctorService.UpdateDoctor(doctor); // Assuming UpdateDoctor is async
                return RedirectToAction("Index");
            }
            return View(doctor);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var doctor = await _doctorService.GetDoctorById(id); // Assuming GetDoctorById is async
            if (doctor == null)
            {
                return Content("Not Found");
            }
            return View(doctor);
        }

        [HttpPost, ActionName("Delete")] // Change to HttpPost for confirmation
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            await _doctorService.RemoveDoctor(id); // Assuming RemoveDoctor is async
            return RedirectToAction("Index");
        }
    }
}
