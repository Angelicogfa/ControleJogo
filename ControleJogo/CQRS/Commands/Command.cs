using CQRS.Messages;
using MediatR;

namespace CQRS.Commands
{
    public class Command : Message, IRequest
    {
        public Command()
        {

        }
    }

    public class CommandResult<T> : Message, IRequest<T>
    {
        public CommandResult()
        {

        }
    }
}
