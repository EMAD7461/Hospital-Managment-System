using System.Threading.Tasks;

namespace Hospital_Managment_System.Service.Interfaces
{
    public interface INotificationService
    {
        /// <summary>
        /// Sends an SMS notification to the specified phone number with the given message.
        /// </summary>
        /// <param name="phoneNumber">The recipient's phone number.</param>
        /// <param name="message">The message to be sent.</param>
        public void SendSMS(string phoneNumber, string message);

        /// <summary>
        /// Sends an email notification to the specified email address with the given subject and message.
        /// </summary>
        /// <param name="email">The recipient's email address.</param>
        /// <param name="subject">The subject of the email.</param>
        /// <param name="message">The message to be sent.</param>
        public Task SendEmailAsync(string email, string subject, string message);
    }
}
