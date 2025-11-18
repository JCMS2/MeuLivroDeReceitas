using MyRecipeBook.Application.Services.AutoMapper;
using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Communication.Responses;
using MyRecipeBook.Exceptions.ExceptionsBase;

namespace MyRecipeBook.Application.UserCases.User.Register
{
    // Classe responsável pela Regra de Negócio de cadastrar um usuário.
    public class RegisterUserUseCase
    {
        // Método principal que executa o cadastro.
        // Recebe os dados da requisição (request) e retorna uma resposta (response).
        public ResponseRegisteredUserJson Execute(ResquestRegistreUserJson resquest)
        {
            // 1. Validação: Chama o método privado para verificar se os dados (email, senha) são válidos.
            Validate(resquest);

            // 2. Configuração do AutoMapper:
            // Inicializa a configuração de mapeamento baseada na classe 'AutoMapping'.
            var autoMapper = new AutoMapper.MapperConfiguration(options =>
            {
                options.AddProfile(new AutoMapping());
            }).CreateMapper();

            // 3. Mapeamento:
            // Converte o objeto de Requisição (DTO) para a Entidade de Domínio (User).
            // Isso prepara o objeto para ser salvo no banco de dados.
            var user = autoMapper.Map<Domain.Entities.User>(resquest);

            // 4. Retorno:
            // Cria e retorna o objeto de resposta contendo o nome do usuário cadastrado.
            return new ResponseRegisteredUserJson
            {
                Nome = resquest.Name,
            };
        }

        // Método auxiliar privado para validar a requisição.
        private void Validate(ResquestRegistreUserJson resquest)
        {
            // Instancia o validador específico para registro de usuários.
            var validator = new RegisterUserValidator();

            // Executa a validação nos dados recebidos.
            var result = validator.Validate(resquest);

            // Se o resultado NÃO for válido (contém erros):
            if (result.IsValid == false)
            {
                // Extrai apenas as mensagens de texto de todos os erros encontrados.
                var erroMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

                // Lança uma exceção personalizada contendo a lista de erros.
                // Isso interrompe o fluxo e retorna os erros para a API.
                throw new ErroOnValidationException(erroMessages);
            }
        }
    }
}