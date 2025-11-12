using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyRecipeBook.Communication.Responses;
using MyRecipeBook.Exceptions;
using MyRecipeBook.Exceptions.ExceptionsBase;
using System;
using System.Net;

namespace MyRecipeBook.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        /// <summary>
        /// O QUE FAZ: É o método principal do filtro, chamado automaticamente pelo ASP.NET Core
        /// sempre que uma exceção não tratada ocorre durante a execução de um Controller.
        /// </summary>
        /// <param name="context">Contém as informações da exceção e do contexto HTTP.</param>
        public void OnException(ExceptionContext context)
        {
            // COMO FAZ:
            // 1. Verifica se a exceção lançada é do tipo 'MyRecipeBookException' (uma exceção customizada do seu projeto).
            if (context.Exception is MyRecipeBookException)
            {
                // 2. Se for, chama o método para lidar com exceções conhecidas do projeto.
                HandleProjectException(context);
            }
            else
            {
                // 3. Se for qualquer outro tipo de exceção (ex: NullReferenceException, etc.),
                // chama o método para lançar um erro genérico (Erro Desconhecido).
                ThrowUnknowException(context);
            }
        }

        /// <summary>
        /// O QUE FAZ: Trata exceções que são 'conhecidas' e fazem parte das regras de negócio
        /// da aplicação (como erros de validação).
        /// </summary>
        /// <param name="context">O contexto da exceção.</param>
        private void HandleProjectException(ExceptionContext context)
        {
            // COMO FAZ:
            // 1. Verifica se a exceção é especificamente um 'ErroOnValidationException'.
            if (context.Exception is ErroOnValidationException)
            {
                // 2. Converte (faz o cast) a exceção genérica para o tipo 'ErroOnValidationException'.
                var exception = context.Exception as ErroOnValidationException;

                // 3. Define o status code da resposta HTTP para 400 (Bad Request).
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                // 4. Cria e define o corpo da resposta (Result) como um JSON padronizado
                //    (RespondeErrorJson), contendo a lista de mensagens de erro vinda da exceção.
                context.Result = new BadRequestObjectResult(new RespondeErrorJson(exception.ErrorMessages));
            }
            // (Aqui poderiam existir outros 'else if' para tratar outros tipos de exceções customizadas)
        }

        /// <summary>
        /// O QUE FAZ: Trata qualquer exceção inesperada ou desconhecida (erros de sistema, bugs, etc.).
        /// </summary>
        /// <param name="context">O contexto da exceção.</param>
        private void ThrowUnknowException(ExceptionContext context)
        {
            // COMO FAZ:
            // 1. Define o status code da resposta HTTP para 500 (Internal Server Error).
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            // 2. Cria e define o corpo da resposta (Result) como um JSON padronizado,
            //    mas com uma mensagem de erro genérica (para não expor detalhes do sistema).
            context.Result = new ObjectResult(new RespondeErrorJson(ResourceMessagesException.UNKNOWN_ERROR));
        }
    }
}