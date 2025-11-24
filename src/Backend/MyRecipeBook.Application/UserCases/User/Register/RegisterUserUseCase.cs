using MyRecipeBook.Application.Services.AutoMapper;
using MyRecipeBook.Application.Services.Ctyptography;
using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Communication.Responses;
using MyRecipeBook.Exceptions.ExceptionsBase;

namespace MyRecipeBook.Application.UserCases.User.Register
{
    // Classe responsável pelo caso de uso de registrar um usuário no sistema.
    public class RegisterUserUseCase
    {
        // Executa o fluxo principal de cadastro do usuário.
        public ResponseRegisteredUserJson Execute(ResquestRegistreUserJson resquest)
        {
            // Instancia o serviço de criptografia de senhas.
            var criptografiaDeSenha = new PasswordEncripter();

            // Configura o AutoMapper usando o profile definido em AutoMapping.
            var autoMapper = new AutoMapper.MapperConfiguration(options =>
            {
                options.AddProfile(new AutoMapping());
            }).CreateMapper();

            // Valida a requisição antes de qualquer operação.
            Validate(resquest);

            // Converte o DTO de requisição para a entidade de domínio User.
            var user = autoMapper.Map<Domain.Entities.User>(resquest);

            // Criptografa a senha antes de salvar a entidade.
            user.Password = criptografiaDeSenha.Encrypt(resquest.Password);

            // Retorna o dado necessário à resposta (por enquanto, apenas o nome).
            return new ResponseRegisteredUserJson
            {
                Nome = resquest.Name,
            };
        }

        // Valida os dados recebidos no DTO de registro.
        private void Validate(ResquestRegistreUserJson resquest)
        {
            // Cria o validador específico para registro de usuário.
            var validator = new RegisterUserValidator();

            // Executa a validação e captura o resultado.
            var result = validator.Validate(resquest);

            // Se possuir erros, lança exceção personalizada contendo todas as mensagens.
            if (result.IsValid == false)
            {
                var erroMessages = result.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ErroOnValidationException(erroMessages);
            }
        }
    }
}
