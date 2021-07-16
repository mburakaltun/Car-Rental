using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<UserForRegisterDTO>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).MinimumLength(2);
            RuleFor(u => u.LastName).MinimumLength(2);
            RuleFor(u => u.Email).MinimumLength(2);
            RuleFor(u => u.Password).MinimumLength(7);
        }
    }
}
