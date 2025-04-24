using Deposito.Application.DTOs;

namespace Deposito.Application.Contracts
{
    public interface IDepositoService
    {
        Task<List<ProdutoDto>> ObterProdutosAsync();
    }
}
