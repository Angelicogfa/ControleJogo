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
        readonly IAmigoDataRead amigoRead;
        readonly IAmigoAppService amigoAppService;

        public AmigosController(IAmigoDataRead amigoRead, IAmigoAppService amigoAppService)
        {
            this.amigoRead = amigoRead;
            this.amigoAppService = amigoAppService;
        }

        [AllowAnonymous]
        public async Task<ActionResult> Index()
        {
            return View(await amigoRead.BuscarTodos());
        }

        public async Task<ActionResult> Details(Guid id)
        {
            var amigo = await amigoRead.BuscarPeloId(id);
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
                model = await amigoAppService.Adicionar(model);

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
            var amigo = await amigoRead.BuscarPeloId(id);
            return View(amigo.ConvertTo<AmigoViewModel>());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AmigoViewModel model)
        {
            if (ModelState.IsValid)
            {
                model = await amigoAppService.Atualizar(model);

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
            var amigo = await amigoRead.BuscarPeloId(id);
            return View(amigo.ConvertTo<AmigoViewModel>());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id, AmigoViewModel model)
        {
            if (ModelState.IsValid)
            {
                model = await amigoAppService.Remover(model);

                if (model.ValidationResult.IsValid)
                    return RedirectToAction("Index");

                foreach (var item in model.ValidationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(model);
        }
    }
}
