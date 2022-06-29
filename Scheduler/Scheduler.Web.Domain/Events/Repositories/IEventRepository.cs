using Scheduler.Web.Domain.Events.Entities;
using Scheduler.Web.Domain.Events.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Web.Domain.Events.Repositories
{
    public interface IEventRepository : IDisposable
    {
        Event GetById(Guid id);
        void Add(Event _event);
        void Update(Event _event);
        void Delete(Event _event);
        Task<IEnumerable<EventQueryResult>> GetAll();
        Task<IEnumerable<EventQueryResult>> GetByDate(DateTime date);
        Task<EventQueryResult> GetByEvent(Guid id);
    }
}
