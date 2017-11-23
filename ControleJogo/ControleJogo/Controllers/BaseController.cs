using CQRS.DomainEvents;
using MediatR;
using System.Collections.Generic;
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

        public IEnumerable<DomainEvent> GetEvents()
        {
            return notificationHandler.Events();
        }

        public string NotifyToJson()
        {
            if (!ExisteNotificacao())
                return string.Empty;

            return Newtonsoft.Json.JsonConvert.SerializeObject(notificationHandler.Events());
        }
    }
}