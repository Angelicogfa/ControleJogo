using ControleJogo.Infra.Identity.Managers;
using ControleJogo.Infra.Identity.ViewModels;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ControleJogo.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly CustomUserManager customUserManager;
        private readonly SingInUserManager _signInManager;

        public AccountController(CustomUserManager customUserManager, SingInUserManager singInUserManager)
        {
            this.customUserManager = customUserManager;
            _signInManager = singInUserManager;
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, shouldLockout: true);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                default:
                    ModelState.AddModelError("", "Login ou Senha incorretos.");
                    return View(model);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}