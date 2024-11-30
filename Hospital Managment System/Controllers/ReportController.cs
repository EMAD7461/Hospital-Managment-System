using Hospital_Managment_System.Models;
using Hospital_Managment_System.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Hospital_Managment_System.Controllers
{
    public class ReportController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly INotificationService _notificationService;

        public ReportController(IAppointmentService appointmentService, INotificationService notificationService)
        {
            _appointmentService = appointmentService;
            _notificationService = notificationService;
        }

        public async Task<IActionResult> CreateReport(int appointmentId)
        {
            var appointment = await _appointmentService.GetAppointmentById(appointmentId);
            if (appointment == null)
            {
                return NotFound("Appointment not found");
            }

            // Simulate report creation
            var report = new Report
            {
                AppointmentId = appointmentId,
                Details = "Sample report details for the patient.",
                CreatedDate = DateTime.Now
            };

            // Here, you would normally save the report to the database
            // Simulate report creation logic
            Console.WriteLine("Report created successfully");

            // Notify patient and doctor if they are available
            if (appointment.Patient?.PhoneNumber != null)
            {
                _notificationService.SendSMS(appointment.Patient.PhoneNumber,
                    $"Your report is ready. Appointment ID: {appointmentId}");
            }

            if (appointment.Doctor?.Email != null)
            {
                await _notificationService.SendEmailAsync(appointment.Doctor.Email,
                    "Report Created",
                    $"A report for patient {appointment.Patient?.Name ?? "Unknown"} has been created.");
            }

            ViewBag.Message = "Report created successfully, and notifications sent.";
            return View();
        }
    }
}
