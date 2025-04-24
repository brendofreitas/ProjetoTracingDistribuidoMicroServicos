using Atendimento.Application.DTOs;
using System.Text.Json;
using Atendimento.Application.Interfaces;

namespace Atendimento.Infrastructure.External
{
    public class DepositoApiClient(HttpClient _httpClient) : IDepositoService
    {
        public async Task<List<ProdutoDto>> ObterProdutosAsync()
        {
            var response = await _httpClient.GetAsync("api/produto");

            if (!response.IsSuccessStatusCode) return [];

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<ProdutoDto>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? [];
        }
    }
}
