using Atendimento.Domain.Entities;
using Atendimento.Domain.Interfaces;

namespace Atendimento.Application.CasoDeUso.Pedido
{
    public class CriarPedidoUseCase
    {
        private readonly IPedidoRepository _pedidoRepository;

        public CriarPedidoUseCase(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task ExecuteAsync(int clienteId, List<ItemPedido> itens)
        {
            if (itens == null || !itens.Any())
                throw new ArgumentException("O pedido deve conter ao menos um item.");

            var pedido = new Domain.Entities.Pedido
            {
                ClienteId = clienteId,
                DataPedido = DateTime.UtcNow,
                Itens = itens
            };

            await _pedidoRepository.Adicionar(pedido);
            await _pedidoRepository.SalvarChanges();
        }
    }

}
