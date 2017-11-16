using System;

namespace CQRS.Messages
{
    public abstract class Message
    {
        public Guid MessageId { get; }
        public string MessageType { get; }
        public DateTime TimeStamp { get; }

        public Message()
        {
            MessageId = Guid.NewGuid();
            MessageType = GetType().Name;
            TimeStamp = DateTime.Now;
        }
    }
}
