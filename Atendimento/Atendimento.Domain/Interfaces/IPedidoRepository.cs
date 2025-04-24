using Atendimento.Domain.Entities;

namespace Atendimento.Domain.Interfaces
{
    public interface IPedidoRepository
    {
        Task Adicionar(Pedido pedido);
        Task<Pedido?> ObterPorId(int id);
        Task<IEnumerable<Pedido>> ObterTodos();
        Task SalvarChanges();
    }
}
