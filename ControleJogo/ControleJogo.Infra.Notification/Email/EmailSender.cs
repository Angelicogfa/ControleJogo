using System.Threading.Tasks;

namespace ControleJogo.Infra.Notification.Email
{
    public class EmailSender : IEmailSender
    {
        public EmailSender()
        {

        }

        public Task Send(string Destinatio, string Assunto, string Conteudo)
        {
            //ToDo para enviar email
            return Task.CompletedTask;
        }
    }
}
