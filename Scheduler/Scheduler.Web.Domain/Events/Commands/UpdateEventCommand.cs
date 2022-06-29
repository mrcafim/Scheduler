using Scheduler.Web.Domain.Core.Commands;
using Scheduler.Web.Domain.Events.Validations;

namespace Scheduler.Web.Domain.Events.Commands
{
    public class UpdateEventCommand : Command
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new UpdateEventValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
