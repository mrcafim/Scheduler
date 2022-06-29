using MediatR;
using Microsoft.AspNetCore.Mvc;
using Scheduler.Web.Domain.Core.Bus;
using Scheduler.Web.Domain.Core.Notifications;

namespace Scheduler.Web.API.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        private readonly DomainNotificationHandler _notifications;
        protected readonly IBus Bus;

        protected BaseController
        (
            INotificationHandler<DomainNotification> notifications,
            IBus bus
        )
        {
            _notifications = (DomainNotificationHandler)notifications;
            Bus = bus;
        }

        protected IEnumerable<DomainNotification> Notifications => _notifications.GetNotifications();

        protected bool IsValid()
        {
            return (!_notifications.HasNotifications());
        }

        protected new async Task<IActionResult> Response()
        {
            if (IsValid())
            {
                return Ok();
            }

            return BadRequest(_notifications.GetNotifications().Select(n => n.Value));
        }
    }
}
