using System.Security.Cryptography;
using System.Text;

namespace MyRecipeBook.Application.Services.Ctyptography
{
    // Serviço responsável por gerar um hash seguro da senha.
    internal class PasswordEncripter
    {
        public string Encrypt(string password)
        {
            // "Sal" fixo adicional para dificultar ataque de dicionário.
            var ChaveAdicional = "ABC";

            // Concatena a senha original com a chave.
            var newPassword = $"{password}{ChaveAdicional}";

            // Converte para bytes usando encoding UTF-8.
            var bytes = Encoding.UTF8.GetBytes(newPassword);

            // Gera o hash SHA512.
            var hashbyter = SHA512.HashData(bytes);

            // Converte os bytes do hash para string hexadecimal.
            return StringBytes(hashbyter);
        }

        // Converte array de bytes em string hexadecimal.
        private static string StringBytes(byte[] bytes)
        {
            var sb = new StringBuilder();

            foreach (byte b in bytes)
            {
                var hex = b.ToString("x2"); // Converte cada byte para formato hex.
                sb.Append(hex);
            }

            return sb.ToString();
        }
    }
}
