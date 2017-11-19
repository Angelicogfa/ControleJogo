using CQRS.DomainEvents;
using MediatR;
using System.Web.Mvc;

namespace ControleJogo.Controllers
{
    public abstract class BaseController : Controller
    {
        private DomainEventHandler notificationHandler;
        public BaseController(IAsyncNotificationHandler<DomainEvent> notificationHandler)
        {
            this.notificationHandler = notificationHandler as DomainEventHandler;
        }

        public bool ExisteNotificacao()
        {
            return notificationHandler.Events().Count > 0;
        }
        
        public void Notify()
        {
            foreach (var item in notificationHandler.Events())
            {
                ModelState.AddModelError(item.Key, item.Value);
            }
        }
    }
}