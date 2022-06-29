using Scheduler.Web.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Web.Domain.Core.Notifications
{
    public class DomainNotification : Event
    {
        public Guid Id { get; private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }

        public DomainNotification(string key, string value)
        {
            Id = Guid.NewGuid();
            Key = key;
            Value = value;
        }
    }
}
