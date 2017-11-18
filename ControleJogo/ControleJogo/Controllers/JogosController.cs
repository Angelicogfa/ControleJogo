using ControleJogo.Aplicacao.InputModel;
using ControleJogo.Aplicacao.Services;
using ControleJogo.Extensions;
using ControleJogo.Infra.DatabaseRead.DataAcess;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ControleJogo.Controllers
{
    [Authorize]
    public class JogosController : Controller
    {
        readonly IJogoDataRead read;
        readonly ICategoriaDataRead categoriaRead;
        readonly IConsoleDataRead consoleRead;
        readonly IJogoAppService service;
        readonly IEmprestimoJogoDataRead emprestimoRead;

        public JogosController(IJogoDataRead read, ICategoriaDataRead categoriaRead, IConsoleDataRead consoleRead, IJogoAppService service, IEmprestimoJogoDataRead emprestimoRead)
        {
            this.read = read;
            this.categoriaRead = categoriaRead;
            this.consoleRead = consoleRead;
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
            return View(await read.BuscarPeloId(id));
        }

        public async Task<ActionResult> Create()
        {
            ViewBag.Categorias = (await categoriaRead.BuscarTodos()).Select(t => new SelectListItem() { Text = t.Descricao, Value = t.Id.ToString() }).ToList();
            ViewBag.Consoles = (await consoleRead.BuscarTodos()).Select(t => new SelectListItem() { Text = t.Descricao, Value = t.Id.ToString() }).ToList();
            return View(new JogoViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(JogoViewModel model, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if(image != null && image.ContentLength > 0 && image.ContentType == "image/png")
                {
                    byte[] buffer = new byte[image.ContentLength];
                    using (BufferedStream stream = new BufferedStream(image.InputStream))
                    {
                        await stream.ReadAsync(buffer, 0, buffer.Length);
                    }
                    model.FotoJogo = buffer;
                }

                model = await service.Adicionar(model);

                if (model.ValidationResult.IsValid)
                    return RedirectToAction("Index");

                foreach (var item in model.ValidationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            ViewBag.Categorias = (await categoriaRead.BuscarTodos()).Select(t => new SelectListItem() { Text = t.Descricao, Value = t.Id.ToString() }).ToList();
            ViewBag.Consoles = (await consoleRead.BuscarTodos()).Select(t => new SelectListItem() { Text = t.Descricao, Value = t.Id.ToString() }).ToList();
            return View(model);
        }

        public async Task<ActionResult> Edit(Guid id)
        {
            ViewBag.Categorias = (await categoriaRead.BuscarTodos()).Select(t => new SelectListItem() { Text = t.Descricao, Value = t.Id.ToString() }).ToList();
            ViewBag.Consoles = (await consoleRead.BuscarTodos()).Select(t => new SelectListItem() { Text = t.Descricao, Value = t.Id.ToString() }).ToList();
            return View((await read.BuscarPeloId(id)).ConvertTo<JogoViewModel>());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(JogoViewModel model, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null && image.ContentLength > 0 && image.ContentType == "image/png")
                {
                    byte[] buffer = new byte[image.ContentLength];
                    using (BufferedStream stream = new BufferedStream(image.InputStream))
                    {
                        await stream.ReadAsync(buffer, 0, buffer.Length);
                    }
                    model.FotoJogo = buffer;
                }
                else
                    model.FotoJogo = await read.CarregarImagem(model.Id); //Garantir que a imagem não seja apagada caso outra não for informada

                model = await service.Atualizar(model);

                if (model.ValidationResult.IsValid)
                    return RedirectToAction("Index");

                foreach (var item in model.ValidationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            ViewBag.Categorias = (await categoriaRead.BuscarTodos()).Select(t => new SelectListItem() { Text = t.Descricao, Value = t.Id.ToString() }).ToList();
            ViewBag.Consoles = (await consoleRead.BuscarTodos()).Select(t => new SelectListItem() { Text = t.Descricao, Value = t.Id.ToString() }).ToList();
            return View(model);
        }

        public async Task<ActionResult> Delete(Guid id)
        {
            return View(await read.BuscarPeloId(id));
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirm(Guid Id)
        {
            var model = (await read.BuscarPeloId(Id)).ConvertTo<JogoViewModel>();
            model = await service.Remover(model);

            if (model.ValidationResult.IsValid)
                return RedirectToAction("Index");

            foreach (var item in model.ValidationResult.Errors)
            {
                ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            }
            return View(await read.BuscarPeloId(Id));
        }

        [HttpGet()]
        [AllowAnonymous]
        [Route("ObterFotoJogo")]
        public async Task<FileContentResult> ObterFotoJogo(Guid Id)
        {
            var imagemJogo = await read.CarregarImagem(Id);
            if (imagemJogo != null && imagemJogo.Length > 0)
                return File(imagemJogo, "image/png");
            else
                return File(System.IO.File.ReadAllBytes(Server.MapPath(Url.Content("~/Content/Image/FotoGameNotFound.png"))), "image/png");
        }

        [HttpGet]
        public async Task<PartialViewResult> ObterEmprestimosParaJogo(Guid Id)
        {
            return PartialView("~/Views/Emprestimos/_emprestimo.cshtml", await emprestimoRead.BuscarTodosParaJogo(Id));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<PartialViewResult> ObterTopJogos()
        {
            return PartialView("_topJogosEmprestados", await emprestimoRead.TopMaisEmprestados());
        }
    }
}
