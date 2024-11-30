using Hospital_Managment_System.Service.Interfaces;
using System.Threading.Tasks;

namespace Hospital_Managment_System.Service.Implementation
{
    public class MockNotificationService : INotificationService
    {
        public void SendSMS(string phoneNumber, string message)
        {
            // Simulate sending SMS by logging to the console
            Console.WriteLine($"SMS to {phoneNumber}: {message}");
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            // Simulate sending email by logging to the console
            Console.WriteLine($"Email to {email} - Subject: {subject} - Message: {message}");
            await Task.CompletedTask;
        }

   
    }
}
