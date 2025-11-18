namespace MyRecipeBook.Domain.Entities
{
    // Classe base para todas as entidades do sistema.
    // Evita repetição de código, pois quase todas as tabelas precisam destes campos.
    public class EntityBase
    {
        // Identificador único (Chave Primária) do registro.
        public long Id { get; set; }

        // Indica se o registro está ativo. 
        // Útil para "Soft Delete" (não apagar dados fisicamente, apenas desativá-los).
        public bool Active { get; set; } = true;

        // Data e hora de criação do registro.
        // Usa UTC para padronizar o horário independente da região do servidor.
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}