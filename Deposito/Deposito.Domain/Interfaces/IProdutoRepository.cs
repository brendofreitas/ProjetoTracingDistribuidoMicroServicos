using Deposito.Domain.Entities;

namespace Deposito.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Task<Produto?> ObterPorIdAsync(int id);
        Task<IEnumerable<Produto>> ListarTodosAsync();
        Task AdicionarAsync(Produto produto);
        Task AtualizarAsync(Produto produto);
        Task<bool> ExisteAsync(int id);
        Task SalvarChangesAsync();
    }
}
