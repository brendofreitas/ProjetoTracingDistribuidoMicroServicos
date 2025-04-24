using Atendimento.Application.DTOs;

namespace Atendimento.Application.Interfaces
{
    public interface IDepositoService
    {
        Task<List<ProdutoDto>> ObterProdutosAsync();
    }
}
