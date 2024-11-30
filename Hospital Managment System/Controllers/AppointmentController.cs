using Hospital_Managment_System.Models;
using Hospital_Managment_System.Service.Interfaces;
using Hospital_Managment_System.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hospital_Managment_System.Controllers
{
        [Authorize(Policy = "AdminOrDoctorPolicy")]
        public class AppointmentController : Controller
        {
            private readonly IAppointmentService _appointmentService;
            private readonly IDoctorService _doctorService;
            private readonly INurseService _nurseService;

            public AppointmentController(IAppointmentService appointmentService, IDoctorService doctorService, INurseService nurseService)
            {
                _appointmentService = appointmentService;
                _doctorService = doctorService;
                _nurseService = nurseService;
            }

            [HttpGet]
            public async Task<IActionResult> Create()
            {
                var viewModel = new AppointmentViewModel
                {
                    Doctors = await _doctorService.GetAllDoctorsAsync(),
                    Nurses = await _nurseService.GetAllNursesAsync(),
                    Appointment = new Appointment() // Initialize a new Appointment object
                };
                return View(viewModel);
            }

            [HttpPost]
            public async Task<IActionResult> Create(AppointmentViewModel viewModel)
            {
                if (ModelState.IsValid)
                {
                    await _appointmentService.AddAppointment(viewModel.Appointment); // Use the Appointment from the ViewModel
                    return RedirectToAction("Index");
                }

                // If validation fails, re-fetch doctors and nurses for the select lists
                viewModel.Doctors = await _doctorService.GetAllDoctorsAsync();
                viewModel.Nurses = await _nurseService.GetAllNursesAsync();
                return View(viewModel);
            var errors = ModelState.Values.SelectMany(v => v.Errors);

        }

        // GET: Appointment/Index
        public async Task<IActionResult> Index()
        {
            var appointments = await _appointmentService.GetAllAppointment(); // Ensure this is async
            return View(appointments);
        }


        // GET: Appointment/Edit/{id}
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var appointment = await _appointmentService.GetAppointmentById(id);
            if (appointment == null) return NotFound();
            return View(appointment);
        }

        


        // POST: Appointment/Edit/{id}
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(appointment);
            }

            await _appointmentService.UpdateAppointment(appointment);
            TempData["Message"] = "Appointment updated successfully!";
            return RedirectToAction("Index");
        }

        // GET: Appointment/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var appointment = await _appointmentService.GetAppointmentById(id);
            if (appointment == null) return NotFound();
            return View(appointment);
        }

        // POST: Appointment/Delete/{id}
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _appointmentService.DeleteAppointment(id);
            TempData["Message"] = "Appointment deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}
