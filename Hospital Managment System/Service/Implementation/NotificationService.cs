using Hospital_Managment_System.Service.Interfaces;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Twilio;

namespace Hospital_Managment_System.Service.Implementation
{
    public class NotificationService : INotificationService
    {
        private readonly IConfiguration _configuration;
        private readonly string _smtpServer = "your_smtp_server"; // e.g., smtp.gmail.com
        private readonly int _smtpPort = 587; // Standard SMTP port for TLS
        private readonly string _smtpUser = "your_email@example.com"; // Your email
        private readonly string _smtpPassword = "your_email_password"; // Your email password
        public NotificationService(IConfiguration configuration)
        {
            _configuration = configuration;

            // Initialize Twilio
            var accountSid = _configuration["Twilio:AccountSid"];
            var authToken = _configuration["Twilio:AuthToken"];
            TwilioClient.Init(accountSid, authToken);
        }

        // This method sends an SMS using a simple HTTP request to your SMS provider's API.
        public void SendSMS(string phoneNumber, string message)
        {
            // Here you would integrate with your SMS provider's API.
            // For example, using Twilio or any other SMS service API.
            // Below is a placeholder for demonstration purposes.

            // Placeholder logic for sending SMS
            // Normally, you would use HttpClient to send a request to the SMS provider's API.
            Console.WriteLine($"Sending SMS to {phoneNumber}: {message}");
            // Actual SMS sending logic would go here.
        }


        // This method sends an email notification asynchronously.
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            using (var smtpClient = new SmtpClient(_smtpServer, _smtpPort))
            {
                smtpClient.Credentials = new NetworkCredential(_smtpUser, _smtpPassword);
                smtpClient.EnableSsl = true;

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_smtpUser),
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = true,
                };
                mailMessage.To.Add(email);

                await smtpClient.SendMailAsync(mailMessage);
                Console.WriteLine($"Email sent to {email} with subject: {subject}");
            }
        }
    }
}
