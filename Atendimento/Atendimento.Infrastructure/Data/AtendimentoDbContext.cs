using Atendimento.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Atendimento.Infrastructure.Data
{
    public class AtendimentoDbContext : DbContext
    {
        public AtendimentoDbContext(DbContextOptions<AtendimentoDbContext> options) : base(options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }
        public DbSet<Interacao> Interacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configurações adicionais se precisar
        }
    }
}
