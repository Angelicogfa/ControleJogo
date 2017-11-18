using ControleJogo.Aplicacao.InputModel;
using ControleJogo.Aplicacao.Services;
using ControleJogo.Extensions;
using ControleJogo.Infra.DatabaseRead.DataAcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ControleJogo.Controllers
{
    [Authorize]
    public class ConsolesController : Controller
    {
        private readonly IConsoleDataRead read;
        private readonly IConsoleAppService service;

        public ConsolesController(IConsoleDataRead read, IConsoleAppService service)
        {
            this.read = read;
            this.service = service;
        }

        public async Task<ActionResult> Index()
        {
            return View(await read.BuscarTodos());
        }

        public async Task<ActionResult> Details(Guid id)
        {
            return View((await read.BuscarPeloId(id)).ConvertTo<ConsoleViewModel>());
        }

        public ActionResult Create()
        {
            return View(new ConsoleViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ConsoleViewModel model)
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
            return View((await read.BuscarPeloId(id)).ConvertTo<ConsoleViewModel>());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ConsoleViewModel model)
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
            return View((await read.BuscarPeloId(id)).ConvertTo<ConsoleViewModel>());
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirm(Guid id)
        {
            var model = (await read.BuscarPeloId(id)).ConvertTo<ConsoleViewModel>();
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
