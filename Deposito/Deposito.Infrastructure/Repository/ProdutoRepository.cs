using Deposito.Domain.Entities;
using Deposito.Domain.Interfaces;
using Deposito.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Deposito.Infrastructure.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DepositoDbContext _context;

        public ProdutoRepository(DepositoDbContext context)
        {
            _context = context;
        }

        public async Task<Produto?> ObterPorIdAsync(int id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task<IEnumerable<Produto>> ListarTodosAsync()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task AdicionarAsync(Produto produto)
        {
            await _context.Produtos.AddAsync(produto);
        }

        public async Task SalvarChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public Task AtualizarAsync(Produto produto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExisteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
