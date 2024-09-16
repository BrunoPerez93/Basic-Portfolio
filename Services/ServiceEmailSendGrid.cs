using SendGrid;
using SendGrid.Helpers.Mail;
using Portfolio.Models;

namespace Portfolio.Services
{
    public interface IServiceEmail
    {
        Task Send(ContactViewModel contact);
    }
    public class ServiceEmailSendGrid : IServiceEmail
    {
        private readonly IConfiguration configuration;

        public ServiceEmailSendGrid(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task Send(ContactViewModel contact)
        {
            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            var email = Environment.GetEnvironmentVariable("SENDGRID_FROM");
            var name = Environment.GetEnvironmentVariable("SENDGRID_NAME");

            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(email, name);
            var subjet = $"El cliente {contact.Email} quiere contactarte";
            var to = new EmailAddress(email, name);
            var message = contact.Message;
            var containHtml = $@"De: {contact.Name} - 
                              Email: {contact.Email}
                              Mensaje: {contact.Message}";
            var singleEmail = MailHelper.CreateSingleEmail(from, to, subjet, message, containHtml);
            var response = await client.SendEmailAsync(singleEmail);
        }
    }
}
