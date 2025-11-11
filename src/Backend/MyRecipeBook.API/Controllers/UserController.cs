using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.Application.UserCases.User.Register;
using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Communication.Responses;

namespace MyRecipeBook.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // Define que este método responde a requisições HTTP POST.
        [HttpPost]
        // Documenta que o tipo de resposta de sucesso será 201 Created.
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
        public IActionResult Register(ResquestRegistreUserJson resquest)
        {
            try
            {
                // Cria uma nova instância do caso de uso (serviço) de registro.
                var useCase = new RegisterUserUseCase();

                // Executa o caso de uso com os dados da requisição.
                var result = useCase.Execute(resquest);

                // Retorna uma resposta HTTP 201 Created com os dados do usuário registrado.
                return Created(string.Empty, result);
            }
            catch (Exception ex)
            {
                // ATENÇÃO: Captura genérica de exceção.
                // O ideal seria capturar 'ErroOnValidationException' e retornar BadRequest (400).
                // Aqui está retornando NotFound (404), o que pode não ser o ideal.
                return NotFound(ex.Message);
            }
        }
    }
}