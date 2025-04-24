using Atendimento.Domain.Interfaces;

namespace Atendimento.Application.CasoDeUso.Cliente
{
    public class ObterClientePorEmailUseCase
    {
        private readonly IClienteRepository _clienteRepository;

        public ObterClientePorEmailUseCase(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Domain.Entities.Cliente?> Executar(string email)
        {
            return await _clienteRepository.ObterPorEmail(email);
        }
    }
}
