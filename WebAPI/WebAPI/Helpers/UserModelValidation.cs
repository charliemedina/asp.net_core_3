using FluentValidation;
using WebAPI.Models;

namespace WebAPI.Validators
{
    public class UserModelValidation : AbstractValidator<UserModel>
    {
        public UserModelValidation()
        {
            RuleFor(user => user.FirstName)
               .NotEmpty()
               .MaximumLength(50);
            RuleFor(user => user.LastName)
               .NotEmpty()
               .MaximumLength(50);
        }
    }

    public class UserModelUpdateValidation : AbstractValidator<UserModel>
    {
        public UserModelUpdateValidation()
        {
            RuleFor(user => user.FirstName)
               .NotEmpty()
               .MaximumLength(50);
            RuleFor(user => user.LastName)
               .NotEmpty()
               .MaximumLength(50);
        }
    }
}
