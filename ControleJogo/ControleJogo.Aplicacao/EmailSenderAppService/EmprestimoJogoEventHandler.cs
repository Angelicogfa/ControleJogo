using ControleJogo.Dominio.Amigos.Repositories;
using ControleJogo.Dominio.Emprestimo.Events;
using ControleJogo.Dominio.Emprestimo.Repository;
using ControleJogo.Dominio.Jogos.Repositories;
using ControleJogo.Infra.Notification.Email;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleJogo.Aplicacao.EmailSenderAppService
{
    public class EmprestimoJogoEventHandler : MediatR.IAsyncNotificationHandler<EmprestimoEfetuadoEvent>
    {
        readonly IEmailSender emailSender;
        readonly IEmprestimoJogoRepository emprestimoRepository;
        readonly IAmigoRepository amigoRepository;
        readonly IJogoRepository jogoRepository;

        public EmprestimoJogoEventHandler(IEmailSender emailSender, 
            IEmprestimoJogoRepository emprestimoRepository,
            IJogoRepository jogoRepository,
            IAmigoRepository amigoRepository)
        {
            this.emailSender = emailSender;
            this.jogoRepository = jogoRepository;
            this.emprestimoRepository = emprestimoRepository;
            this.amigoRepository = amigoRepository;
        }

        public async Task Handle(EmprestimoEfetuadoEvent notification)
        {
            
            var emprestimo = await emprestimoRepository.ProcurarPeloId(notification.EmprestimoId);
            var nomeJogo = jogoRepository.Buscar().Where(t => t.Id == emprestimo.JogoId).Select(t => t.Nome).FirstOrDefault();
            var emailAmigo = amigoRepository.Buscar().Where(t => t.Id == emprestimo.AmigoId).Select(t => t.Email).FirstOrDefault();

            StringBuilder html = new StringBuilder();
            html.AppendLine("<!DOCTYPE html>");
            html.AppendLine("<html>");
            html.AppendLine("<head>");
            html.AppendLine("</head>");
            html.AppendLine("<body>");
            html.AppendLine("<h1> Emprestimo efetudo!</ h1 >");
            html.AppendLine($"<p> Aproveite o seu empréstimo e curta a vontade o jogo <strong>{nomeJogo}</strong></p>");
            html.AppendLine("<br/>");
            html.AppendLine($"<p> Não se esqueça que a data de devolução é <strong>{emprestimo.DataDevolucao.ToString("dd/MM/yyyy")}</strong></p>");
            html.AppendLine("</body>");
            html.AppendLine("</html>");

            //await emailSender.Send(emailAmigo, "Emprestimo Jogo Efetaduado", html.ToString());
        }
    }
}
