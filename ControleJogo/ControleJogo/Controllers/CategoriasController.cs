using ControleJogo.Infra.DatabaseRead.DataAcess;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using ControleJogo.Extensions;
using ControleJogo.Aplicacao.InputModel;
using ControleJogo.Aplicacao.Services;

namespace ControleJogo.Controllers
{
    [Authorize]
    public class CategoriasController : Controller
    {
        private readonly ICategoriaDataRead categoriaRead;
        private readonly ICategoriaAppService service;

        public CategoriasController(ICategoriaDataRead categoriaRead, ICategoriaAppService service)
        {
            this.categoriaRead = categoriaRead;
            this.service = service;
        }

        public async Task<ActionResult> Index()
        {
            return View(await categoriaRead.BuscarTodos());
        }

        public async Task<ActionResult> Details(Guid id)
        {
            return View((await categoriaRead.BuscarPeloId(id)).ConvertTo<CategoriaViewModel>());
        }

        public ActionResult Create()
        {
            return View(new CategoriaViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CategoriaViewModel model)
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
            return View((await categoriaRead.BuscarPeloId(id)).ConvertTo<CategoriaViewModel>());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CategoriaViewModel model)
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
            return View((await categoriaRead.BuscarPeloId(id)).ConvertTo<CategoriaViewModel>());
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirm(Guid id)
        {
            var model = (await categoriaRead.BuscarPeloId(id)).ConvertTo<CategoriaViewModel>();
            model = await service.Remover(model);

            if (model.ValidationResult.IsValid)
                return RedirectToAction("Index");

            foreach (var item in model.ValidationResult.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View(model);
        }
    }
}
