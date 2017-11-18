using ControleJogo.Aplicacao.Services;
using ControleJogo.Infra.DatabaseRead.DataAcess;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ControleJogo.Controllers
{
    [Authorize]
    public class EmprestimosController : Controller
    {
        readonly IEmprestimoJogoDataRead read;
        readonly IAmigoDataRead amigosRead;
        readonly IJogoDataRead jogosRead;
        readonly IEmprestimoJogoAppService service;

        public EmprestimosController(IEmprestimoJogoDataRead read, 
            IAmigoDataRead amigosRead, 
            IJogoDataRead jogosRead, 
            IEmprestimoJogoAppService service)
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
            var result = await service.NovoEmprestimo(Jogo, Amigo);
            if(!result.IsValid)
            {
                foreach (var erro in result.Errors)
                    ModelState.AddModelError(erro.PropertyName, erro.ErrorMessage);
            }
            return RedirectToAction("BuscarEmprestimos", new { Amigo = Amigo, Jogo = Jogo });
        }

        [HttpPost]
        [Route("AtualizarStatusDevolucao")]
        public async Task<ActionResult> AtualizarStatusDevolucao(Guid Id, bool Devolvido)
        {
            var result = await service.AtualizarStatusEmprestimo(Id, Devolvido);

            if (!result.IsValid)
            {
                foreach (var erro in result.Errors)
                    ModelState.AddModelError(erro.PropertyName, erro.ErrorMessage);
            }

            var emprestimo = await read.BuscarPeloId(Id);
            return RedirectToAction("BuscarEmprestimos", new { Amigo = emprestimo.AmigoId, Jogo = emprestimo.JogoId });
        }

        [AllowAnonymous]
        public async Task<PartialViewResult> BuscarEmprestimos(Guid? Amigo = null, Guid? Jogo = null)
        {
            return PartialView("_emprestimo", await read.BuscarTodosParaJogoAmigo(Amigo, Jogo));
        }
    }
}