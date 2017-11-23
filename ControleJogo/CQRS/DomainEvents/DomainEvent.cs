using CQRS.Commands;
using CQRS.Events;
using MediatR;
using System;
using System.Runtime.Serialization;

namespace CQRS.DomainEvents
{
    [Serializable]
    [DataContract]
    public class DomainEvent : Command, INotification
    {
        [DataMember]
        public string Key { get; private set; }
        [DataMember]
        public string Value { get; private set; }

        public DomainEvent(string Key, string Value)
        {
            this.Key = Key;
            this.Value = Value;
        }
    }
}
