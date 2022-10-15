using FluentValidation;
using OES.API.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OES.API.Application.Validators
{
    public class AppCompanyValidator : AbstractValidator<AppCompany>
    {
        public AppCompanyValidator()
        {
            RuleFor(b => b.Name).NotNull().MinimumLength(1);
            RuleFor(b => b.UserName).NotNull().MinimumLength(1);
            RuleFor(b => b.Email).NotNull().EmailAddress();
        }
    }
}
