using CQRS.Events;

namespace CQRS.DomainEvents
{
    public class DomainEvent : Event
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
