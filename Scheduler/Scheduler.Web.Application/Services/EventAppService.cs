using Scheduler.Web.Application.Interfaces;
using Scheduler.Web.Domain.Core.Bus;
using Scheduler.Web.Domain.Core.Commands;
using Scheduler.Web.Domain.Events.Commands;
using Scheduler.Web.Domain.Events.Queries;
using Scheduler.Web.Domain.Events.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Web.Application.Services
{

    public class EventAppService : IEventAppService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IBus _bus;

        public EventAppService(IEventRepository eventRepository,
                               IBus bus)
        {
            _eventRepository = eventRepository;
            _bus = bus;
        }

        public async Task<IEnumerable<EventQueryResult>> GetAll()
        {
            return await _eventRepository.GetAll();
        }
        public async Task<IEnumerable<EventQueryResult>> GetByDate(DateTime date)
        {
            return await _eventRepository.GetByDate(date);
        }

        public async Task<EventQueryResult> GetById(Guid id)
        {
            return await _eventRepository.GetByEvent(id);
        }

        public async Task<CommandResult> Add(AddEventCommand command)
        {
            return await _bus.SendCommand(command);
        }

        public async Task<CommandResult> Update(UpdateEventCommand command)
        {
            return await _bus.SendCommand(command);
        }

        public async Task<CommandResult> Delete(Guid id)
        {
            var delete = new DeleteEventCommand { Id = id };
            return await _bus.SendCommand(delete);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
