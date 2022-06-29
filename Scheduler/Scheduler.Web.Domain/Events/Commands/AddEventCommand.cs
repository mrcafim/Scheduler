using Scheduler.Web.Domain.Core.Commands;
using Scheduler.Web.Domain.Events.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Web.Domain.Events.Commands
{
    public class AddEventCommand : Command
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new AddEventValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
