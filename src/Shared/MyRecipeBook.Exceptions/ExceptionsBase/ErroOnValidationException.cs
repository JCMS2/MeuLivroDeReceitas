using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Assume que existe uma classe base 'MyRecipeBookException'
namespace MyRecipeBook.Exceptions.ExceptionsBase
{
    // Define uma exceção específica para erros de validação.
    public class ErroOnValidationException : MyRecipeBookException
    {
        // Propriedade que armazena a lista de mensagens de erro.
        public IList<string> ErrorMessages { get; set; }

        // Construtor que recebe a lista de erros quando a exceção é criada.
        public ErroOnValidationException(IList<string> erros)
        {
            ErrorMessages = erros;
        }
    }
}