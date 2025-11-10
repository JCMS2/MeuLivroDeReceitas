using FluentValidation;
using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Exceptions;

namespace MyRecipeBook.Application.UserCases.User.Register
{
    internal class RegisterUserValidator : AbstractValidator <ResquestRegistreUserJson>
    {
        public RegisterUserValidator()
        {
            RuleFor(user => user.Nome).NotEmpty().WithMessage(ResourceMessagesException.NAME_EMPTY);
            RuleFor(user => user.Email).NotEmpty().WithMessage(ResourceMessagesException.EMAIL_EMPTY);
            RuleFor(user => user.Email).EmailAddress().WithMessage(ResourceMessagesException.EMAIL_VALIDO);
            RuleFor(user => user.Password.Length).GreaterThanOrEqualTo(6).WithMessage(ResourceMessagesException.SENHA_VALIDA);
        }
    }
}
 