using Scheduler.Web.Domain.Core.Commands;
using Scheduler.Web.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Web.Domain.Core.Bus
{
    public interface IBus
    {
        Task<CommandResult> SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
