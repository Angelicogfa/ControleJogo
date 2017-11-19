using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRS.DomainEvents
{
    public class DomainEventHandler : IAsyncNotificationHandler<DomainEvent>,
        IAsyncRequestHandler<DomainEvent>
    {
        private List<DomainEvent> events = null;

        public DomainEventHandler()
        {
            events = new List<DomainEvent>();
        }

       

        public IReadOnlyList<DomainEvent> Events()
        {
            return events.AsReadOnly();
        }

        public Task Handle(DomainEvent notification)
        {
            events.Add(notification);
            return Task.CompletedTask;
        }
    }
}
