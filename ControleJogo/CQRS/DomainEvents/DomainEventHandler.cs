using MediatR;
using System;
using System.Collections.Generic;

namespace CQRS.DomainEvents
{
    public class DomainEventHandler : INotificationHandler<DomainEvent>, IDisposable
    {
        private List<DomainEvent> events = null;

        public DomainEventHandler()
        {
            events = new List<DomainEvent>();
        }

        public void Dispose()
        {
            events = new List<DomainEvent>();
        }

        public void Handle(DomainEvent notification)
        {
            events.Add(notification);
        }

        public IReadOnlyList<DomainEvent> Events()
        {
            return events.AsReadOnly();
        }
    }
}
