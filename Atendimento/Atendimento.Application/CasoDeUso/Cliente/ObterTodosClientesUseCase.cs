using Atendimento.Domain.Interfaces;

namespace Atendimento.Application.CasoDeUso.Cliente
{
    public class ObterTodosClientesUseCase
    {
        private readonly IClienteRepository _clienteRepository;

        public ObterTodosClientesUseCase(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<Domain.Entities.Cliente>> Executar()
        {
            return await _clienteRepository.ObterTodos();
        }
    }
}
