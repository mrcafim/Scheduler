using MediatR;
using Scheduler.Web.Domain.Core.Bus;
using Scheduler.Web.Domain.Core.Commands;
using Scheduler.Web.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Web.Infra.Bus
{
    public sealed class InMemoryBus : IBus
    {
        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<CommandResult> SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }

        public Task RaiseEvent<T>(T @event) where T : Event
        {
            return _mediator.Publish(@event);
        }
    }
}
