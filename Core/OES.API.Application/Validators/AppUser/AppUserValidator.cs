﻿using FluentValidation;
using OES.API.Domain.Identity;
using System;
using System.Collections.Generic;

namespace OES.API.Application.Validators
{
    public class AppUserValidator : AbstractValidator<AppUser>
    {
        public AppUserValidator()
        {
            RuleFor(b => b.Name).NotNull().MinimumLength(1);
            RuleFor(b => b.UserName).NotNull().MinimumLength(1);
            RuleFor(b => b.Email).NotNull().EmailAddress();
        }
    }
}
