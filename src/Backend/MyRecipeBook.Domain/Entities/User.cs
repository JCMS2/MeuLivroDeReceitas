namespace MyRecipeBook.Domain.Entities
{
    // Esta classe representa a tabela de Usuários no banco de dados.
    // Ela herda de 'EntityBase', aproveitando campos comuns como ID e Data de Criação.
    public class User : EntityBase
    {
        // Propriedade para armazenar o nome do usuário.
        // Inicializada com string.Empty para evitar valores nulos (null).
        public string Name { get; set; } = string.Empty;

        // Propriedade para armazenar o e-mail do usuário.
        public string Email { get; set; } = string.Empty;

        // Propriedade para armazenar a senha. 
        // Nota: Geralmente armazena-se o hash da senha aqui, não a senha em texto plano.
        public string Password { get; set; } = string.Empty;
    }
}