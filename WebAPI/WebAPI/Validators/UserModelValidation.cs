using FluentValidation;
using WebAPI.Models;

namespace WebAPI.Validators
{
    public class UserModelValidation : AbstractValidator<UserModel>
    {
        public UserModelValidation()
        {
            RuleFor(user => user.FullName)
               .NotEmpty()
               .MaximumLength(100);
        }
    }

    public class UserModelUpdateValidation : AbstractValidator<UpdateModel>
    {
        public UserModelUpdateValidation()
        {
            RuleFor(user => user.FullName)
               .NotEmpty()
               .MaximumLength(100);
        }
    }
}
