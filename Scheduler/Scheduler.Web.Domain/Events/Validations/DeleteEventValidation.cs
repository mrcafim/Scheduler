using FluentValidation;
using Scheduler.Web.Domain.Events.Commands;

namespace Scheduler.Web.Domain.Events.Validations
{
    public class DeleteEventValidation : AbstractValidator<DeleteEventCommand>
    {
        public DeleteEventValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required");
        }
    }
}
