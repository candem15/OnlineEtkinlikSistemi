using FluentValidation;
using OES.API.Application.Features.Commands.AppCompany.RegisterCompany;

namespace OES.API.Application.Validators
{
    public class RegisterCompanyValidator : AbstractValidator<RegisterCompanyCommandRequest>
    {
        public RegisterCompanyValidator()
        {
            RuleFor(b => b.Name).NotNull().MinimumLength(1);
            RuleFor(b => b.Username).NotNull().MinimumLength(1);
            RuleFor(b => b.Email).NotNull().EmailAddress();
            RuleFor(b => b.Password).NotEmpty().WithMessage("Şifre boş geçilemez.")
                    .MinimumLength(8).WithMessage("Şifreniz en az 8 karakter içermelidir.")
                    .Matches(@"[A-Za-z]+").WithMessage("Şifreniz en az 1 harf içermelidir.")
                    .Matches(@"[0-9]+").WithMessage("Şifreniz en az 1 rakam içermelidir.");
            RuleFor(b => b.PasswordConfirm).Equal(b => b.Password);
            RuleFor(b => b.WebsiteDomain).NotEmpty().NotNull();

        }
    }
}
