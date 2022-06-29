using FluentValidation;
using Scheduler.Web.Domain.Events.Commands;

namespace Scheduler.Web.Domain.Events.Validations
{
    public class UpdateEventValidation : AbstractValidator<UpdateEventCommand>
    {
        public UpdateEventValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required");

            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("StartDate is required");

            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage("EndDate is required");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required");

            RuleFor(x => x.Location)
                .NotEmpty().WithMessage("Location is required");
        }
    }
}
