using ControleJogo.Infra.DatabaseRead.DataAcess;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ControleJogo.Controllers
{
    [Authorize]
    public class JogosController : Controller
    {
        readonly IJogoDataRead read;

        public JogosController(IJogoDataRead read)
        {
            this.read = read;
        }

        [AllowAnonymous]
        public async Task<ActionResult> Index()
        {
            return View(await read.BuscarTodos());
        }

        
        public ActionResult Details(Guid id)
        {
            return View();
        }

        // GET: Jogo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jogo/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Jogo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Jogo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Jogo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Jogo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet()]
        [AllowAnonymous]
        [Route("ObterFotoJogo")]
        public async Task<FileContentResult> ObterFotoJogo(Guid Id)
        {
            var imagemJogo = await read.CarregarImagem(Id);
            if (imagemJogo != null && imagemJogo.FotoJogo != null && imagemJogo.FotoJogo.Length > 0)
                return File(imagemJogo.FotoJogo, "png");
            else
                return File(System.IO.File.ReadAllBytes(Server.MapPath(Url.Content("~/Content/Image/FotoGameNotFound.png"))), "png");
        }
    }
}
