using FluentValidation;
using OES.API.Application.Features.Commands.City.CreateCity;

namespace OES.API.Application.Validators
{
    public class CreateCityValidator : AbstractValidator<CreateCityCommandRequest>
    {
        public CreateCityValidator()
        {
            RuleFor(c => c.CityName).NotNull().MinimumLength(1);
        }
    }
}
