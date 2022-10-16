using FluentValidation;
using OES.API.Application.Features.Commands.Category.CreateCategory;

namespace OES.API.Application.Validators
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommandRequest>
    {
        public CreateCategoryValidator()
        {
            RuleFor(c => c.CategoryName).NotNull().MinimumLength(1);
        }
    }
}
