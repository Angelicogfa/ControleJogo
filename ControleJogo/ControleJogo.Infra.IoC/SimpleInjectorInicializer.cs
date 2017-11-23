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
using ControleJogo.Infra.Identity.Storage;
using ControleJogo.Infra.Identity.Managers;
using ControleJogo.Aplicacao.Services;
using ControleJogo.Infra.DatabaseRead.DataAcess;
using ControleJogo.Infra.Data.Contexto;
using CQRS.DomainEvents;
using System.Reflection;

namespace ControleJogo.Infra.IoC
{
    public class SimpleInjectorInicializer
    {
        public static void Inicialize(Container container)
        {
            //Contexto
            container.Register<ControleJogoContext>(Lifestyle.Scoped);
            ControleJogoContext.Inicialize();

            //UnitOfWork
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);

            //Repository
            container.Register<ICategoriaRepository, CategoriaRepository>(Lifestyle.Scoped);
            container.Register<IConsoleRepository, ConsoleRepository>(Lifestyle.Scoped);
            container.Register<IJogoRepository, JogoRepository>(Lifestyle.Scoped);
            container.Register<IAmigoRepository, AmigoRepository>(Lifestyle.Scoped);
            container.Register<IEmprestimoJogoRepository, EmprestimoJogoRepository>(Lifestyle.Scoped);

            //Services
            container.Register<ICategoriaService, CategoriaService>(Lifestyle.Scoped);
            container.Register<IConsoleService, ConsoleService>(Lifestyle.Scoped);
            container.Register<IJogoService, JogoService>(Lifestyle.Scoped);
            container.Register<IAmigoService, AmigoService>(Lifestyle.Scoped);

            //Mediator
            Assembly[] assemblies =
            {
                typeof(EmprestarJogosSaga).GetTypeInfo().Assembly,
                typeof(DomainEventHandler).GetTypeInfo().Assembly,
                typeof(EmprestimoJogoEventHandler).GetTypeInfo().Assembly,
            };

            container.BuildMediator(assemblies);
            container.Register(typeof(IRequestHandler<,>), assemblies, Lifestyle.Scoped);
            container.Register(typeof(IAsyncRequestHandler<,>), assemblies, Lifestyle.Scoped);
            container.Register(typeof(IRequestHandler<>), assemblies, Lifestyle.Scoped);
            container.Register(typeof(IAsyncRequestHandler<>), assemblies, Lifestyle.Scoped);
            container.Register(typeof(ICancellableAsyncRequestHandler<>), assemblies, Lifestyle.Scoped);
            container.Register(typeof(INotificationHandler<>), assemblies, Lifestyle.Scoped);
            container.Register(typeof(IAsyncNotificationHandler<>), assemblies, Lifestyle.Scoped);
            container.Register(typeof(ICancellableAsyncNotificationHandler<>), assemblies, Lifestyle.Scoped);
            
            container.Register<ICategoriaAppService, CategoriaAppService>(Lifestyle.Scoped);
            container.Register<IConsoleAppService, ConsoleAppService>(Lifestyle.Scoped);
            container.Register<IJogoAppService, JogoAppService>(Lifestyle.Scoped);
            container.Register<IAmigoAppService, AmigoAppService>(Lifestyle.Scoped);
            container.Register<IEmprestimoJogoAppService, EmprestimoJogoAppService>(Lifestyle.Scoped);

            //External Services
            //Email
            container.Register<IEmailSender, EmailSender>(Lifestyle.Scoped);

            //DatabaseRead
            container.Register<ICategoriaDataRead, CategoriaFacadeRead>(Lifestyle.Scoped);
            container.Register<IConsoleDataRead, ConsoleFacadeRead>(Lifestyle.Scoped);
            container.Register<IJogoDataRead, JogoFacadeRead>(Lifestyle.Scoped);
            container.Register<IAmigoDataRead, AmigoFacadeRead>(Lifestyle.Scoped);
            container.Register<IEmprestimoJogoDataRead, EmprestimoJogoFacadeRead>(Lifestyle.Scoped);

            //Identity
            container.Register<UserContext>(Lifestyle.Scoped);
            container.Register<UserStore>(Lifestyle.Scoped);
            container.Register<CustomUserManager>(Lifestyle.Scoped);
            container.Register<SingInUserManager>(Lifestyle.Scoped);


            UserContext.Inicialize();
        }
    }
}
