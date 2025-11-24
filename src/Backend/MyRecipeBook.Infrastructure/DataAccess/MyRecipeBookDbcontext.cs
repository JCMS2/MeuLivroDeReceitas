using Microsoft.EntityFrameworkCore;
using MyRecipeBook.Domain.Entities;

namespace MyRecipeBook.Infrastructure.DataAccess
{
    // DbContext responsável pela conexão e mapeamento das entidades com o banco de dados.
    internal class MyRecipeBookDbcontext : DbContext
    {
        // Construtor recebe as configurações de DbContext (connection string, provider, etc.).
        public MyRecipeBookDbcontext(DbContextOptions options) : base(options)
        {
        }

        // Representa a tabela Users no banco de dados.
        public DbSet<User> Users { get; set; }

        // Aplica automaticamente todas configurações de entidades (EntityTypeConfiguration)
        // presentes no assembly do projeto Infrastructure.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyRecipeBookDbcontext).Assembly);
        }
    }
}
