using ControleJogo.Aplicacao.Services;
using ControleJogo.Infra.DatabaseRead.DataAcess;
using CQRS.DomainEvents;
using MediatR;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ControleJogo.Controllers
{
    [Authorize]
    public class EmprestimosController : BaseController
    {
        readonly IEmprestimoJogoDataRead read;
        readonly IAmigoDataRead amigosRead;
        readonly IJogoDataRead jogosRead;
        readonly IEmprestimoJogoAppService service;

        public EmprestimosController(
            INotificationHandler<DomainEvent> notificationHandler,
            IEmprestimoJogoDataRead read, 
            IAmigoDataRead amigosRead, 
            IJogoDataRead jogosRead, 
            IEmprestimoJogoAppService service) : base(notificationHandler)
        {
            this.read = read;
            this.amigosRead = amigosRead;
            this.jogosRead = jogosRead;
            this.service = service;
        }
        
        [AllowAnonymous]
        public async Task<ActionResult> Index()
        {
            ViewBag.Amigos = (await amigosRead.BuscarTodos()).Select(t => new SelectListItem() { Text = t.Nome, Value = t.Id.ToString() }).ToList();
            ViewBag.Jogos = (await jogosRead.BuscarTodos()).Select(t => new SelectListItem() { Text = t.Nome, Value = t.Id.ToString() }).ToList();
            return View();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Create(Guid Amigo, Guid Jogo)
        {
            await service.NovoEmprestimo(Jogo, Amigo);
            Notify();
            return RedirectToAction("BuscarEmprestimos", new { Amigo = Amigo, Jogo = Jogo });
        }

        [HttpPost]
        [Route("DevolverJogo")]
        public async Task<ActionResult> DevolverJogo(Guid Id)
        {
            await service.DevolverJogoEmprestado(Id);
            Notify();
            var emprestimo = await read.BuscarPeloId(Id);
            return RedirectToAction("BuscarEmprestimos", new { Amigo = emprestimo.AmigoId });
        }

        [HttpPost]
        [Route("RenovarEmprestimo")]
        public async Task<ActionResult> RenovarEmprestimo(Guid Id)
        {
            await service.RenovarJogoEmprestimo(Id);
            Notify();
            var emprestimo = await read.BuscarPeloId(Id);
            return RedirectToAction("BuscarEmprestimos", new { Amigo = emprestimo.AmigoId });
        }

        [AllowAnonymous]
        public async Task<PartialViewResult> BuscarEmprestimos(Guid? Amigo = null, Guid? Jogo = null, bool? Devolvido= null)
        {
            return PartialView("_emprestimo", await read.BuscarTodosParaJogoAmigo(Amigo, Jogo, Devolvido));
        }
    }
}