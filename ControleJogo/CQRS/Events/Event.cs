using CQRS.Messages;
using MediatR;

namespace CQRS.Events
{
    public class Event : Message, INotification
    {
        public Event()
        {

        }
    }
}
