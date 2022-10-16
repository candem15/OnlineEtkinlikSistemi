using FluentValidation;
using OES.API.Application.Features.Commands.Category.UpdateCategory;

namespace OES.API.Application.Validators
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryCommandRequest>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
            RuleFor(c => c.CategoryName).NotEmpty().MinimumLength(2);
        }
    }
}
