using Scheduler.Web.Domain.Core.Commands;
using Scheduler.Web.Domain.Events.Commands;
using Scheduler.Web.Domain.Events.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Web.Application.Interfaces
{
    public interface IEventAppService : IDisposable
    {
        Task<IEnumerable<EventQueryResult>> GetAll();
        Task<EventQueryResult> GetById(Guid id);
        Task<CommandResult> Add(AddEventCommand command);
        Task<CommandResult> Update(UpdateEventCommand command);
        Task<CommandResult> Delete(Guid id);

    }
}
