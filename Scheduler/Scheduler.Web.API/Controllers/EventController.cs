using MediatR;
using Microsoft.AspNetCore.Mvc;
using Scheduler.Web.Domain.Core.Bus;
using Scheduler.Web.Domain.Core.Notifications;
using Scheduler.Web.Domain.Events.Commands;
using Scheduler.Web.Domain.Events.Repositories;

namespace Scheduler.Web.API.Controllers
{

    [Route("event")]
    public class EventController : BaseController
    {
        private readonly IEventRepository _eventRepository;

        public EventController
        (
            IEventRepository eventRepository,
            INotificationHandler<DomainNotification> notifications,
            IBus bus
        ) : base(notifications, bus)
        {
            _eventRepository = eventRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _eventRepository.GetAll());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetByEvent(Guid id)
        {
            return Ok(await _eventRepository.GetByEvent(id));
        }

        [HttpPost]
        public Task<IActionResult> Add([FromBody] AddEventCommand command)
        {
            Bus.SendCommand(command);
            return Response();
        }

        [HttpPut]
        public Task<IActionResult> Put([FromBody] UpdateEventCommand command)
        {
            Bus.SendCommand(command);
            return Response();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteEventCommand { Id = id };

            Bus.SendCommand(command);
            return Response();
        }
    }
}
