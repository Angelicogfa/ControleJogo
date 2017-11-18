using ControleJogo.Aplicacao.InputModel;
using ControleJogo.Aplicacao.Services;
using ControleJogo.Extensions;
using ControleJogo.Infra.DatabaseRead.DataAcess;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ControleJogo.Controllers
{
    [Authorize]
    public class AmigosController : Controller
    {
        readonly IAmigoDataRead read;
        readonly IAmigoAppService service;
        readonly IEmprestimoJogoDataRead emprestimoRead;

        public AmigosController(IAmigoDataRead read, IAmigoAppService service, IEmprestimoJogoDataRead emprestimoRead)
        {
            this.read = read;
            this.service = service;
            this.emprestimoRead = emprestimoRead;
        }

        [AllowAnonymous]
        public async Task<ActionResult> Index()
        {
            return View(await read.BuscarTodos());
        }

        public async Task<ActionResult> Details(Guid id)
        {
            var amigo = await read.BuscarPeloId(id);
            return View(amigo.ConvertTo<AmigoViewModel>());
        }

        public ActionResult Create()
        {
            return View(new AmigoViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AmigoViewModel model)
        {
            if (ModelState.IsValid)
            {
                model = await service.Adicionar(model);

                if (model.ValidationResult.IsValid)
                    return RedirectToAction("Index");

                foreach (var item in model.ValidationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(model);
        }

        public async Task<ActionResult> Edit(Guid id)
        {
            var amigo = await read.BuscarPeloId(id);
            return View(amigo.ConvertTo<AmigoViewModel>());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AmigoViewModel model)
        {
            if (ModelState.IsValid)
            {
                model = await service.Atualizar(model);

                if (model.ValidationResult.IsValid)
                    return RedirectToAction("Index");

                foreach (var item in model.ValidationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(model);
        }

        public async Task<ActionResult> Delete(Guid id)
        {
            var amigo = await read.BuscarPeloId(id);
            return View(amigo.ConvertTo<AmigoViewModel>());
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirm(Guid id)
        {
            var model = (await read.BuscarPeloId(id)).ConvertTo<AmigoViewModel>();
            model = await service.Remover(model);

            if (model.ValidationResult.IsValid)
                return RedirectToAction("Index");

            foreach (var item in model.ValidationResult.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View(model);
        }

        [HttpGet]
        public async Task<PartialViewResult> ObterEmprestimosParaAmigo(Guid Id)
        {
            return PartialView("~/Views/Emprestimos/_emprestimo.cshtml", await emprestimoRead.BuscarTodosParaAmigo(Id));
        }
    }
}
