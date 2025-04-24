using Atendimento.Domain.Interfaces;

namespace Atendimento.Application.CasoDeUso.Cliente
{
    public class CriarClienteUseCase
    {
        private readonly IClienteRepository _clienteRepository;

        public CriarClienteUseCase(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task Executar(Domain.Entities.Cliente cliente)
        {
            await _clienteRepository.Adicionar(cliente);
            await _clienteRepository.SalvarChanges();
        }
    }
}
