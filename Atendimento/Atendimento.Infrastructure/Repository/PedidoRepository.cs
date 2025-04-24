using Atendimento.Domain.Entities;
using Atendimento.Domain.Interfaces;
using Atendimento.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Atendimento.Infrastructure.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AtendimentoDbContext _context;

        public PedidoRepository(AtendimentoDbContext context)
        {
            _context = context;
        }

        public async Task Adicionar(Pedido pedido)
        {
            await _context.Pedidos.AddAsync(pedido);
        }

        public async Task<Pedido?> ObterPorId(int id)
        {
            return await _context.Pedidos
                .Include(p => p.Itens)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Pedido>> ObterTodos()
        {
            return await _context.Pedidos
                .Include(p => p.Itens)
                .ToListAsync();
        }

        public async Task SalvarChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
