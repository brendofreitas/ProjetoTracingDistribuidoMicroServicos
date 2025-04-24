using Atendimento.Domain.Entities;
using Atendimento.Domain.Interfaces;
using Atendimento.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Atendimento.Infrastructure.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AtendimentoDbContext _context;

        public ClienteRepository(AtendimentoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> ObterTodos()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente?> ObterPorId(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task<Cliente?> ObterPorIdComPedidosEInteracoes(int id)
        {
            return await _context.Clientes
                .Include(c => c.Pedidos)
                .Include(c => c.Interacoes)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task Adicionar(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
        }

        public async Task SalvarChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Cliente?> ObterPorEmail(string email)
        {
            return await _context.Clientes.FirstOrDefaultAsync(c => c.Email == email);
        }
    }
}
