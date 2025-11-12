using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipeBook.Communication.Responses
{
    public class RespondeErrorJson
    {
        public IList<string> Errors { get; set; }

        /// <summary>
        /// O QUE FAZ: Construtor que aceita uma lista de mensagens de erro.
        /// </summary>
        /// <param name="errors">Uma lista de strings contendo as mensagens de erro.</param>
        public RespondeErrorJson(IList<string> errors)
        {
            // COMO FAZ: Simplesmente atribui a lista recebida à propriedade 'Errors'.
            Errors = errors;
        }

        /// <summary>
        /// O QUE FAZ: Construtor auxiliar (sobrecarga) que aceita uma única string de erro.
        /// </summary>
        /// <param name="error">Uma única string de erro.</param>
        public RespondeErrorJson(string error)
        {
            // COMO FAZ:
            // 1. Cria uma nova lista de strings.
            // 2. Adiciona a string de erro única a essa nova lista.
            // 3. Atribui a nova lista à propriedade 'Errors'.
            Errors = new List<string>
            {
                error
            };
        }
    }
}