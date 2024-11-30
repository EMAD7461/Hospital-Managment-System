using Hospital_Managment_System.Models;
using Hospital_Managment_System.Repositry.Interfaces;
using Hospital_Managment_System.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Managment_System.Service.Implementation
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly INotificationService _notificationService;

        public AppointmentService(IAppointmentRepository appointmentRepository, INotificationService notificationService)
        {
            _appointmentRepository = appointmentRepository;
            _notificationService = notificationService;
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointment()
        {
            return await _appointmentRepository.GetAllAppointmentAsync(); // Make sure this method is async
        }

        public async Task<Appointment> GetAppointmentById(int id)
        {
            return await _appointmentRepository.GetAppointmentByIdAsync(id); // Assuming this method is async
        }

        public async Task AddAppointment(Appointment appointment)
        {
            // Check if the patient has completed appointments
            if (await HasCompletedAppointments(appointment.PatientId))
            {
                throw new InvalidOperationException("Patient cannot book an appointment because they have completed appointments.");
            }

            await _appointmentRepository.AddAppointmentAsync(appointment); // Assuming this method is async
            // Send a notification for the new appointment
            await SendAppointmentReminder(appointment);
        }

        public async Task UpdateAppointment(Appointment appointment)
        {
            await _appointmentRepository.UpdateAppointmentAsync(appointment); // Assuming this method is async
            // Send a notification for the updated appointment
            await SendAppointmentReminder(appointment);
        }

        public async Task DeleteAppointment(int id)
        {
            await _appointmentRepository.DeleteAppointmentAsync(id); // Assuming this method is async
        }

        public async Task<bool> HasCompletedAppointments(int? patientId)
        {
            // Return false if the patientId is null
            if (patientId == null)
            {
                return false;
            }

            // Fetch all appointments asynchronously and check for completed ones
            var appointments = await _appointmentRepository.GetAllAppointmentAsync(); // Make sure this method is async

            return appointments.Any(a => a.PatientId == patientId && a.Status == "Completed");
        }

        private async Task SendAppointmentReminder(Appointment appointment)
        {
            var patient = appointment.Patient;
            var doctor = appointment.Doctor;

            // Send SMS reminder
            _notificationService.SendSMS(patient.PhoneNumber,
                $"Reminder: You have an appointment with Dr. {doctor?.Name ?? "Unknown"} on {appointment.AppointmentDate}.");

            // Send email reminder
            await _notificationService.SendEmailAsync(patient.Email,
                "Appointment Reminder",
                $"Dear {patient.Name},\n\nThis is a reminder for your upcoming appointment with Dr. {doctor?.Name ?? "Unknown"} on {appointment.AppointmentDate}.\n\nThank you.");
        }
    }
}
