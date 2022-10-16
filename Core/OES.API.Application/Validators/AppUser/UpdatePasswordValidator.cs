using FluentValidation;
using OES.API.Application.Features.Commands.AppUser.UpdatePassword;

namespace OES.API.Application.Validators
{
    public class UpdatePasswordValidator : AbstractValidator<UpdatePasswordCommandRequest>
    {
        public UpdatePasswordValidator()
        {
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş geçilemez.")
                    .MinimumLength(8).WithMessage("Şifreniz en az 8 karakter içermelidir.")
                    .Matches(@"[A-Za-z]+").WithMessage("Şifreniz en az 1 harf içermelidir.")
                    .Matches(@"[0-9]+").WithMessage("Şifreniz en az 1 rakam içermelidir.");
        }
    }
}
