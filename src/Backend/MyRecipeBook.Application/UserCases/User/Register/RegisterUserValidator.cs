using FluentValidation;
using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Exceptions; // Assume que 'ResourceMessagesException' está aqui.

namespace MyRecipeBook.Application.UserCases.User.Register
{
    // Define um validador para a classe 'ResquestRegistreUserJson'.
    internal class RegisterUserValidator : AbstractValidator<ResquestRegistreUserJson>
    {
        // O construtor é onde todas as regras de validação são definidas.
        public RegisterUserValidator()
        {
            // Regra: A propriedade 'Nome' não pode ser vazia ou nula.
            RuleFor(user => user.Name).NotEmpty().WithMessage(ResourceMessagesException.NAME_EMPTY);

            // Regra: A propriedade 'Email' não pode ser vazia ou nula.
            RuleFor(user => user.Email).NotEmpty().WithMessage(ResourceMessagesException.EMAIL_EMPTY);

            // Regra: A propriedade 'Email' deve ter um formato de email válido.
            RuleFor(user => user.Email).EmailAddress().WithMessage(ResourceMessagesException.EMAIL_VALIDO);

            // Regra: O comprimento (Length) da 'Password' deve ser maior ou igual a 6.
            RuleFor(user => user.Password.Length).GreaterThanOrEqualTo(6).WithMessage(ResourceMessagesException.SENHA_VALIDA);
        }
    }
}