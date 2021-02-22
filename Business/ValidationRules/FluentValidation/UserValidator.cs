﻿using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.FirstName).MinimumLength(5);
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.FirstName).MinimumLength(5);
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Email).EmailAddress();
            RuleFor(u => u.PassWord).NotEmpty();
            RuleFor(u => u.PassWord).MinimumLength(2);




        }
    }
}
