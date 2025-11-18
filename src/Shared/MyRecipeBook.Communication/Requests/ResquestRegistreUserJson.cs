namespace MyRecipeBook.Communication.Requests
{
    // Classe DTO (Data Transfer Object).
    // Representa o JSON que o Front-end ou API Client envia para registrar um usuário.
    public class ResquestRegistreUserJson
    {
        // Nome digitado pelo usuário.
        public string Name { get; set; } = string.Empty;

        // E-mail digitado pelo usuário.
        public string Email { get; set; } = string.Empty;

        // Senha digitada pelo usuário (em texto puro).
        public string Password { get; set; } = string.Empty;
    }
}