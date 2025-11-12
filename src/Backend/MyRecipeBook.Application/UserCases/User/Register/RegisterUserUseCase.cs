using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Communication.Responses;
using MyRecipeBook.Exceptions.ExceptionsBase;

namespace MyRecipeBook.Application.UserCases.User.Register
{
    public class RegisterUserUseCase
    {
        /// <summary>
        /// O QUE FAZ: Executa a lógica de negócio principal para registrar um novo usuário.
        /// </summary>
        /// <param name="resquest">Os dados do usuário a ser registrado (Nome, Email, etc.)</param>
        /// <returns>Uma resposta com os dados do usuário recém-registrado.</returns>
        public ResponseRegisteredUserJson Execute(ResquestRegistreUserJson resquest)
        {
            // COMO FAZ:
            // 1. Chama o método privado 'Validate' para verificar se os dados recebidos são válidos.
            Validate(resquest);

            // 2. Se a validação passar (não lançar exceção), ele cria a resposta.
            // (Aqui futuramente existiria a lógica para salvar no banco de dados)
            // 3. Retorna um objeto 'ResponseRegisteredUserJson' com o nome do usuário.
            return new ResponseRegisteredUserJson
            {
                Nome = resquest.Nome,
            };
        }

        /// <summary>
        /// O QUE FAZ: Valida os dados da requisição de registro de usuário.
        /// </summary>
        /// <param name="resquest">Os dados da requisição.</param>
        private void Validate(ResquestRegistreUserJson resquest)
        {
            // COMO FAZ:
            // 1. Cria uma instância do 'RegisterUserValidator' (que provavelmente usa FluentValidation).
            var validator = new RegisterUserValidator();

            // 2. Executa o validador nos dados da requisição.
            var result = validator.Validate(resquest);

            // 3. Verifica se o resultado da validação NÃO é válido.
            if (result.IsValid == false)
            {
                // 4. Se for inválido, coleta todas as mensagens de erro da validação.
                var erroMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

                // 5. Lança uma exceção customizada ('ErroOnValidationException') contendo a lista de erros.
                //    (Esta exceção será capturada pelo 'ExceptionFilter')
                throw new ErroOnValidationException(erroMessages);
            }
        }
    }
}