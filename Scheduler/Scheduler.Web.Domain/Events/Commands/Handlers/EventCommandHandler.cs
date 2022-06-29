using MediatR;
using Scheduler.Web.Domain.Core.Bus;
using Scheduler.Web.Domain.Core.Commands;
using Scheduler.Web.Domain.Core.Notifications;
using Scheduler.Web.Domain.Core.Transactions;
using Scheduler.Web.Domain.Events.Entities;
using Scheduler.Web.Domain.Events.Repositories;

namespace Scheduler.Web.Domain.Events.Commands.Handlers
{
    public class EventCommandHandler : CommandHandler,
        IRequestHandler<AddEventCommand, CommandResult>,
        IRequestHandler<DeleteEventCommand, CommandResult>,
        IRequestHandler<UpdateEventCommand, CommandResult>
    {
        private readonly IEventRepository _eventRepository;

        public EventCommandHandler
        (
            IEventRepository eventRepository,
            IUnitOfWork uow,
            IBus bus,
            INotificationHandler<DomainNotification> notifications
        ) : base(uow, bus, notifications)
        {
            _eventRepository = eventRepository;
        }
        public Task<CommandResult> Handle(AddEventCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!ValidateCommand(command))
                    return Task.FromResult(new CommandResult(false));

                var _event = new Event
                (
                    command.StartDate,
                    command.EndDate,
                    command.Title,
                    command.Location,
                    command.Description
                );

                _eventRepository.Add(_event);

                return Task.FromResult(new CommandResult(Commit()));
            }
            catch (Exception e)
            {
                RaiseDomainNotification(command.MessageType, e.Message);
                return Task.FromResult(new CommandResult(false));
            }
        }

        public Task<CommandResult> Handle(DeleteEventCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!ValidateCommand(command))
                    return Task.FromResult(new CommandResult(false));

                var _event = _eventRepository.GetById(command.Id);

                if (_event == null)
                {
                    RaiseDomainNotification(command.MessageType, "Event not found");
                    return Task.FromResult(new CommandResult(false));
                }

                _event.Delete();
                _event.Deactivate();

                _eventRepository.Update(_event);

                return Task.FromResult(new CommandResult(Commit()));
            }
            catch (Exception e)
            {
                RaiseDomainNotification(command.MessageType, e.Message);
                return Task.FromResult(new CommandResult(false));
            }
        }

        public Task<CommandResult> Handle(UpdateEventCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (!ValidateCommand(command))
                    return Task.FromResult(new CommandResult(false));

                var _event = _eventRepository.GetById(command.Id);

                if (_event == null)
                {
                    RaiseDomainNotification(command.MessageType, "Event not found.");
                    return Task.FromResult(new CommandResult(false));
                }

                _event.UpdateEvent
                (
                    command.StartDate,
                    command.EndDate,
                    command.Title,
                    command.Location,
                    command.Description
                );

                _eventRepository.Update(_event);

                return Task.FromResult(new CommandResult(Commit()));
            }
            catch (Exception e)
            {
                RaiseDomainNotification(command.MessageType, e.Message);
                return Task.FromResult(new CommandResult(false));
            }
        }
    }
}
