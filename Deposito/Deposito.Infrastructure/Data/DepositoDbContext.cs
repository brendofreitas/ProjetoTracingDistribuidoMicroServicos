using Deposito.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Deposito.Infrastructure.Data
{
    public class DepositoDbContext : DbContext
    {
        public DepositoDbContext(DbContextOptions<DepositoDbContext> options) : base(options)
        {
        }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var produtos = new List<Produto>();
            var random = new Random();

            for (int i = 1; i <= 20; i++)
            {
                produtos.Add(new Produto
                {
                    Id = i,
                    Nome = $"Produto {i}",
                    Preco = (decimal)(i * 5.25)
                });
            }

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id)
                      .ValueGeneratedOnAdd(); // também deixa claro que o ID é gerado
            });

            modelBuilder.Entity<Produto>().HasData(produtos);
            base.OnModelCreating(modelBuilder);
        }
    }
}
