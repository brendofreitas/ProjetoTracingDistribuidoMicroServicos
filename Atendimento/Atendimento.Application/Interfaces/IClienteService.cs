using Atendimento.Domain.Entities;

namespace Atendimento.Application.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> ObterTodos();
        Task<Cliente?> ObterPorIdComPedidosEInteracoes(int id);
        Task Adicionar(Cliente cliente);
    }
}
