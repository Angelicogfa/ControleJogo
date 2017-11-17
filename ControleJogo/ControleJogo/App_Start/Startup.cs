using ControleJogo.Infra.Identity.Managers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System.Web.Mvc;

namespace ControleJogo
{
    public partial class Startup
    {
        public void Configure(IAppBuilder app)
        {
            app.CreatePerOwinContext(()=> DependencyResolver.Current.GetService<CustomUserManager>());

            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new Microsoft.Owin.PathString(""),
                Provider = new CookieAuthenticationProvider()
            });

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
        }
    }
}