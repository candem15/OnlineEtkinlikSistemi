using FluentValidation;
using OES.API.Application.Features.Commands.Event.UpdateEvent;

namespace OES.API.Application.Validators
{
    public class UpdateEventValidator : AbstractValidator<UpdateEventCommandRequest>
    {
        public UpdateEventValidator()
        {
            RuleFor(c => c.Id).NotNull().NotEmpty();
            RuleFor(c => c.Address).NotNull().MinimumLength(10);
            RuleFor(c => c.MaxParticipantsNumber).NotNull().GreaterThan(2);
        }
    }
}
