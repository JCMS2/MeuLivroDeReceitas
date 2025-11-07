using FluentValidation;
using MyRecipeBook.Communication.Requests;

namespace MyRecipeBook.Application.UserCases.User.Register
{
    internal class RegisterUserValidator : AbstractValidator <ResquestRegistreUserJson>
    {
        public RegisterUserValidator()
        {
            RuleFor(user => user.Nome).NotEmpty();
            RuleFor(user => user.Email).NotEmpty();
            RuleFor(user => user.Email).EmailAddress();
            RuleFor(user => user.Password.Length).GreaterThanOrEqualTo(6);
        }
    }
}
