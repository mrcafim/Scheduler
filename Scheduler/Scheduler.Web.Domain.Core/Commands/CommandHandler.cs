using MediatR;
using Scheduler.Web.Domain.Core.Bus;
using Scheduler.Web.Domain.Core.Events;
using Scheduler.Web.Domain.Core.Notifications;
using Scheduler.Web.Domain.Core.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Web.Domain.Core.Commands
{
    public class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IBus _bus;
        private readonly INotificationHandler<DomainNotification> _notifications;

        public bool InTransaction => _uow.InTransaction;

        public CommandHandler(IUnitOfWork uow, IBus bus, INotificationHandler<DomainNotification> notifications)
        {
            _uow = uow;
            _notifications = (DomainNotificationHandler)notifications;
            _bus = bus;
        }

        protected bool ValidateCommand(Command command)
        {
            if (command == null)
            {
                RaiseDomainNotification(nameof(command), "Invalid parameters");
                return false;
            }

            var result = command.IsValid();

            if (!result)
                NotifyValidationErrors(command);

            return result;
        }

        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.ValidationResult.Errors)
                RaiseDomainNotification(message.MessageType, error.ErrorMessage);
        }

        protected void RaiseDomainNotification(string key, string Amount)
        {
            _bus.RaiseEvent(new DomainNotification(key, Amount));
        }

        protected Task RaiseEvent<T>(T @event) where T : Event
        {
            return _bus.RaiseEvent(@event);
        }

        protected Task<CommandResult> SendCommand<T>(T command) where T : Command
        {
            return _bus.SendCommand(command);
        }

        protected void Begin()
        {
            _uow.Begin();
        }

        protected bool Commit()
        {
            if (_uow.Commit())
                return true;

            RaiseDomainNotification("Commit", "An error occurred while saving the data");
            return false;
        }

        protected void Rollback()
        {
            _uow.Rollback();
        }
    }
}
