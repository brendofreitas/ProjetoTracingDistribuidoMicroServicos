using Deposito.Domain.Interfaces;

namespace Deposito.Application.CasosDeUso.Produto
{
    public class ConsultarProdutoUseCase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ConsultarProdutoUseCase(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<Domain.Entities.Produto?> ExecuteAsync(int id)
        {
            return await _produtoRepository.ObterPorIdAsync(id);
        }

        public async Task<IEnumerable<Domain.Entities.Produto>> ExecuteTodosAsync()
        {
            return await _produtoRepository.ListarTodosAsync();
        }
    }
}
