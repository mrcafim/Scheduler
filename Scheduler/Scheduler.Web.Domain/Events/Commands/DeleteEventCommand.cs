using Scheduler.Web.Domain.Core.Commands;
using Scheduler.Web.Domain.Events.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Web.Domain.Events.Commands
{
    public class DeleteEventCommand : Command
    {
        public Guid Id { get; set; }
        public bool Deleted { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new DeleteEventValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
