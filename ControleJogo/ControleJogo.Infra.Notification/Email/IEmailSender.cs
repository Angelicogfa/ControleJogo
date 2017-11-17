using System.Threading.Tasks;

namespace ControleJogo.Infra.Notification.Email
{
    public interface IEmailSender
    {
        Task Send(string Destinatio, string Assunto, string Conteudo);
    }
}
