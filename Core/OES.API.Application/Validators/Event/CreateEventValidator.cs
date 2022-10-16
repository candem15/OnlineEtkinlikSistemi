using FluentValidation;
using OES.API.Application.Features.Commands.Event.CreateEvent;

namespace OES.API.Application.Validators
{
    public class CreateEventValidator : AbstractValidator<CreateEventCommandRequest>
    {
        public CreateEventValidator()
        {
            RuleFor(c => c.EventName).NotNull().MinimumLength(1);
            RuleFor(c => c.Address).NotNull().MinimumLength(10);
            RuleFor(c => c.MaxParticipantsNumber).NotNull().GreaterThan(1);
            RuleFor(c => c.CategoryId).NotNull().NotEmpty();
            RuleFor(c => c.CityId).NotNull().NotEmpty();
            RuleFor(c => c.TicketPrice).GreaterThan(0);
            RuleFor(c => c.Description).NotNull().MinimumLength(15);
            RuleFor(c => c.ApplicationDeadline).NotNull().GreaterThanOrEqualTo(c => c.EventDate);
            RuleFor(c => c.EventDate).NotNull().LessThanOrEqualTo(c => c.ApplicationDeadline);
        }
    }
}
