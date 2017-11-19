using CQRS.Commands;
using CQRS.Events;
using MediatR;

namespace CQRS.DomainEvents
{
    public class DomainEvent : Command, INotification
    {
        public string Key { get; private set; }
        public string Value { get; private set; }

        public DomainEvent(string Key, string Value)
        {
            this.Key = Key;
            this.Value = Value;
        }
    }
}
