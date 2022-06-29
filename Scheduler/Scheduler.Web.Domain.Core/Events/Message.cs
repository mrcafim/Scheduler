using MediatR;
using Scheduler.Web.Domain.Core.Commands;

namespace Scheduler.Web.Domain.Core.Events
{
    public abstract class Message : IRequest<CommandResult>
    {
        public string MessageType { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}
