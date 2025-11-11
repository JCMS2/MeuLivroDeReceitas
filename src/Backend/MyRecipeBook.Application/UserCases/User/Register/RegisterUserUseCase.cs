using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Communication.Responses;
using MyRecipeBook.Exceptions.ExceptionsBase;

namespace MyRecipeBook.Application.UserCases.User.Register
{
    public class RegisterUserUseCase
    {
        // Método principal que executa a lógica de registro.
        public ResponseRegisteredUserJson Execute(ResquestRegistreUserJson resquest)
        {
            // Valida a requisição antes de prosseguir.
            Validate(resquest);

            // Se a validação passar, retorna a resposta (ainda sem salvar no banco).
            return new ResponseRegisteredUserJson
            {
                Nome = resquest.Nome,
            };
        }

        // Método privado que encapsula a lógica de validação.
        private void Validate(ResquestRegistreUserJson resquest)
        {
            var validator = new RegisterUserValidator();
            var result = validator.Validate(resquest);

            // Verifica se a validação falhou.
            if (result.IsValid == false)
            {
                // Coleta as mensagens de erro do FluentValidation.
                var erroMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

                // Lança a exceção customizada contendo a lista de erros.
                throw new ErroOnValidationException(erroMessages);
            }
        }
    }
}