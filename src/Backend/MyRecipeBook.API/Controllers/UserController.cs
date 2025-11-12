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
        /// <summary>
        /// O QUE FAZ: Este é o endpoint da API para registrar um novo usuário.
        /// Ele é ativado por uma requisição HTTP POST para a rota '.../user'.
        /// </summary>
        /// <param name="resquest">Os dados do usuário (JSON) vindos no corpo da requisição.</param>
        /// <returns>Uma resposta HTTP (201 Created) com os dados do usuário registrado.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
        public IActionResult Register(ResquestRegistreUserJson resquest)
        {
            // COMO FAZ:
            // 1. Cria uma nova instância do 'RegisterUserUseCase' (a classe que contém a lógica de negócio).
            var useCase = new RegisterUserUseCase();

            // 2. Executa o caso de uso, passando os dados da requisição ('resquest').
            var result = useCase.Execute(resquest);

            // 3. Retorna uma resposta HTTP 201 (Created), que indica que um novo recurso
            //    foi criado com sucesso. O 'result' é incluído no corpo da resposta (serializado como JSON).
            return Created(string.Empty, result);
        }
    }
}