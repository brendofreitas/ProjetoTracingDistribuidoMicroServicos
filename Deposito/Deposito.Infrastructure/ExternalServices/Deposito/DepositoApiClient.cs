using Deposito.Application.Contracts;
using Deposito.Application.DTOs;
using System.Text.Json;

namespace Deposito.Infrastructure.ExternalServices.Deposito
{
    public class DepositoApiClient : IDepositoService
    {
        private readonly HttpClient _httpClient;

        public DepositoApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProdutoDto>> ObterProdutosAsync()
        {
            var response = await _httpClient.GetAsync("api/produtos");

            if (!response.IsSuccessStatusCode)
                return new List<ProdutoDto>();

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<ProdutoDto>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
    }

}
