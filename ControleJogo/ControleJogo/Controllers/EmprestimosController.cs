using ControleJogo.Infra.DatabaseRead.DataAcess;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ControleJogo.Controllers
{
    [Authorize]
    public class EmprestimosController : Controller
    {
        readonly IEmprestimoJogoDataRead read;

        public EmprestimosController(IEmprestimoJogoDataRead read)
        {
            this.read = read;
        }
        
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public async Task<PartialViewResult> BuscarEmprestimos(Guid? Amigo = null, Guid? Jogo = null)
        {
            return null;
        }
    }
}