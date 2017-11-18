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
        [Route("DevolverJogo")]
        public async Task<ActionResult> DevolverJogo(Guid Id)
        {
            var result = await service.DevolverJogoEmprestado(Id);

            if (!result.IsValid)
            {
                foreach (var erro in result.Errors)
                    ModelState.AddModelError(erro.PropertyName, erro.ErrorMessage);
            }

            var emprestimo = await read.BuscarPeloId(Id);
            return RedirectToAction("BuscarEmprestimos", new { Amigo = emprestimo.AmigoId });
        }

        [HttpPost]
        [Route("RenovarEmprestimo")]
        public async Task<ActionResult> RenovarEmprestimo(Guid Id)
        {
            var result = await service.RenovarJogoEmprestimo(Id);

            if (!result.IsValid)
            {
                foreach (var erro in result.Errors)
                    ModelState.AddModelError(erro.PropertyName, erro.ErrorMessage);
            }

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