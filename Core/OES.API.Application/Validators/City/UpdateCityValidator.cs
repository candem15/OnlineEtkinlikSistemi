using FluentValidation;
using OES.API.Application.Features.Commands.City.UpdateCity;

namespace OES.API.Application.Validators
{
    public class UpdateCityValidator : AbstractValidator<UpdateCityCommandRequest>
    {
        public UpdateCityValidator()
        {
            RuleFor(c => c.Id).NotEmpty().NotNull();
            RuleFor(c => c.CityName).NotNull().NotEmpty();
        }
    }
}
