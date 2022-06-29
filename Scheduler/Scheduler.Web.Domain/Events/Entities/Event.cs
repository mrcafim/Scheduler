using Scheduler.Web.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Web.Domain.Events.Entities
{
    public class Event : Entity
    {
        protected Event() { }

        public Event(DateTime startDate, DateTime endDate, string title, string location, string description)
        {
            StartDate = startDate;
            EndDate = endDate;
            Title = title;
            Location = location;
            Description = description;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Active = true;
            Deleted = false;
        }

        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public bool Active { get; private set; }
        public bool Deleted { get; set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string Title { get; private set; }
        public string Location { get; private set; }
        public string Description { get; private set; }

        public void Deactivate()
        {
            Active = false;
            UpdatedAt = DateTime.Now;
        }

        public void Delete()
        {
            Deleted = true;
            UpdatedAt = DateTime.Now;
        }

        public void UpdateEvent(DateTime startDate, DateTime endDate, string title, string location, string description)
        {
            StartDate = startDate;
            EndDate = endDate;
            Title = title;
            Location = location;
            Description = description;
            UpdatedAt = DateTime.Now;
        }

    }
}
