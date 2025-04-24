using Atendimento.Domain.Entities;

namespace Atendimento.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> ObterTodos();
        Task<Cliente?> ObterPorId(int id);
        Task<Cliente?> ObterPorIdComPedidosEInteracoes(int id);
        Task Adicionar(Cliente cliente);
        Task<Cliente?> ObterPorEmail(string email);
        Task SalvarChanges();
    }
}
