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
            IAsyncNotificationHandler<DomainEvent> notificationHandler,
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
            if (!ExisteNotificacao())
                return Json(new { result = true, url = Url.Action("BuscarEmprestimos", new { Amigo = Amigo, Jogo = Jogo }) });
            else
                return Json(new { result = false, mensagem = GetEvents() });
        }

        [HttpPost]
        [Route("DevolverJogo")]
        public async Task<ActionResult> DevolverJogo(Guid Id)
        {
            await service.DevolverJogoEmprestado(Id);
            if (!ExisteNotificacao())
            {
                var emprestimo = await read.BuscarPeloId(Id);
                return Json(new { result = true, url = Url.Action("BuscarEmprestimos", new { Amigo = emprestimo.AmigoId }) });
            }
            else
                return Json(new { result = false, mensagem = GetEvents() });
        }

        [HttpPost]
        [Route("RenovarEmprestimo")]
        public async Task<ActionResult> RenovarEmprestimo(Guid Id)
        {
            await service.RenovarJogoEmprestimo(Id);
            if (!ExisteNotificacao())
            {
                var emprestimo = await read.BuscarPeloId(Id);
                return Json(new { result = true, url = Url.Action("BuscarEmprestimos", new { Amigo = emprestimo.AmigoId }) });
            }
            else
                return Json(new { result = false, mensagem = GetEvents() });

        }

        [AllowAnonymous]
        public async Task<PartialViewResult> BuscarEmprestimos(Guid? Amigo = null, Guid? Jogo = null, bool? Devolvido = null)
        {
            return PartialView("_emprestimo", await read.BuscarTodosParaJogoAmigo(Amigo, Jogo, Devolvido));
        }
    }
}