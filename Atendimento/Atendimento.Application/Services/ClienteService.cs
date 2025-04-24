using Atendimento.Application.CasoDeUso.Cliente;
using Atendimento.Domain.Entities;

namespace Atendimento.Application.Services
{
    public class ClienteService
    {
        private readonly ObterTodosClientesUseCase _obterTodosClientesUseCase;
        private readonly CriarClienteUseCase _criarClienteUseCase;
        private readonly ObterClienteComPedidosEInteracoesUseCase _obterClienteComPedidosEInteracoesUseCase;
        private readonly ObterClientePorEmailUseCase _obterClientePorEmailUseCase;

        public ClienteService(
            ObterTodosClientesUseCase obterTodosClientesUseCase,
            CriarClienteUseCase criarClienteUseCase,
            ObterClienteComPedidosEInteracoesUseCase obterClienteComPedidosEInteracoesUseCase,
            ObterClientePorEmailUseCase obterClientePorEmailUseCase)
        {
            _obterTodosClientesUseCase = obterTodosClientesUseCase;
            _criarClienteUseCase = criarClienteUseCase;
            _obterClienteComPedidosEInteracoesUseCase = obterClienteComPedidosEInteracoesUseCase;
            _obterClientePorEmailUseCase = obterClientePorEmailUseCase;
        }


        public async Task<IEnumerable<Cliente>> ObterTodos()
        {
            return await _obterTodosClientesUseCase.Executar();
        }

        public async Task Adicionar(Cliente cliente)
        {
            await _criarClienteUseCase.Executar(cliente);
        }

        public async Task<Cliente?> ObterPorIdComPedidosEInteracoes(int id)
        {
            return await _obterClienteComPedidosEInteracoesUseCase.Executar(id);
        }

        public async Task<Cliente?> ObterPorEmail(string email)
        {
            return await _obterClientePorEmailUseCase.Executar(email);
        }
    }
}
