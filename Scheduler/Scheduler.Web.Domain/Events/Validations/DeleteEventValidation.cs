using FluentValidation;
using Scheduler.Web.Domain.Events.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
