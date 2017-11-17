using System.Net.Mail;
using System.Threading.Tasks;

namespace ControleJogo.Infra.Notification.Email
{
    public class EmailSender : IEmailSender
    {
        private const string email = "";
        private const string senha = "";
        private SmtpClient smtpClient;
        public EmailSender()
        {
            smtpClient = new SmtpClient("smtp.gmail.com")
            {
                EnableSsl = true,
                Credentials = new System.Net.NetworkCredential(email, senha)
            };
        }

        public Task Send(string Destinatio, string Assunto, string Conteudo)
        {
            try
            {
                MailMessage mail = new MailMessage(email, Destinatio, Assunto, Conteudo)
                {
                    IsBodyHtml = true,
                    Priority = MailPriority.High
                };
                smtpClient.Send(mail);
                return Task.CompletedTask;
            }
            catch (System.Exception ex)
            {
                return Task.FromException(ex);
            }
        }
    }
}
