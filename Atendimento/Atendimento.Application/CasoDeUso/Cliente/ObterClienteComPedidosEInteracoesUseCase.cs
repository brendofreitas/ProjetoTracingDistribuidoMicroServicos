using Atendimento.Domain.Interfaces;

namespace Atendimento.Application.CasoDeUso.Cliente
{
    public class ObterClienteComPedidosEInteracoesUseCase
    {
        private readonly IClienteRepository _clienteRepository;

        public ObterClienteComPedidosEInteracoesUseCase(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Domain.Entities.Cliente?> Executar(int id)
        {
            return await _clienteRepository.ObterPorIdComPedidosEInteracoes(id);
        }
    }
}
