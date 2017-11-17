using ControleJogo.Dominio.Amigos.Repositories;
using ControleJogo.Dominio.Emprestimo.Repository;
using ControleJogo.Dominio.Jogos.Repositories;
using ControleJogo.Infra.Data.Repositories;
using ControleJogo.Infra.Data.UoW;
using DomainDrivenDesign.Repositories;
using SimpleInjector;
using MediatR.SimpleInjector;
using ControleJogo.Dominio.Emprestimo.Commands;
using ControleJogo.Dominio.Emprestimo.Sagas;
using MediatR;
using ControleJogo.Dominio.Jogos.Services;
using ControleJogo.Dominio.Amigos.Services;
using ControleJogo.Dominio.Emprestimo.Events;
using ControleJogo.Aplicacao.EmailSenderAppService;
using ControleJogo.Infra.Notification.Email;

namespace ControleJogo.Infra.IoC
{
    public class SimpleInjectorInicializer
    {
        public static void Inicialize(Container container)
        {
            //Contexto
            container.Register<Data.Contexto.ControleJogoContext>(Lifestyle.Scoped);

            //UnitOfWork
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);

            //Repository
            container.Register<ICategoriaRepository, CategoriaRepository>(Lifestyle.Scoped);
            container.Register<IJogoRepository, JogoRepository>(Lifestyle.Scoped);
            container.Register<IAmigoRepository, AmigoRepository>(Lifestyle.Scoped);
            container.Register<IEmprestimoJogoRepository, EmprestimoJogoRepository>(Lifestyle.Scoped);

            //Services
            container.Register<ICategoriaService, CategoriaService>(Lifestyle.Scoped);
            container.Register<IJogoService, JogoService>(Lifestyle.Scoped);
            container.Register<IAmigoService, AmigoService>(Lifestyle.Scoped);

            //Mediator
            container.BuildMediator();

            //Commands e Events
            container.Register<IAsyncRequestHandler<NovoEmprestimoCommand>, EmprestarJogosSaga>(Lifestyle.Scoped);
            container.Register<IAsyncNotificationHandler<JogoNaoDisponivelEvent>, EmprestarJogosSaga>(Lifestyle.Scoped);

            //Aplicacao
            container.Register<IAsyncNotificationHandler<EmprestimoEfetuadoEvent>, EmprestimoJogoEventHandler>(Lifestyle.Scoped);

            //External Services
            //Email
            container.Register<IEmailSender, EmailSender>(Lifestyle.Scoped);
        }
    }
}
