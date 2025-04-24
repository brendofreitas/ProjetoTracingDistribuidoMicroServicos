using Atendimento.Application.DTOs;
using System.Text.Json;
using Atendimento.Application.Interfaces;
using System.Diagnostics;

namespace Atendimento.Infrastructure.External
{
    public class DepositoApiClient(HttpClient _httpClient) : IDepositoService
    {
        private static readonly ActivitySource ActivitySource = new("Atendimento.DepositoApiClient");

        public async Task<List<ProdutoDto>> ObterProdutosAsync()
        {
            using var activity = ActivitySource.StartActivity("ObterProdutos");

            try
            {
                var response = await _httpClient.GetAsync("api/produto");

                activity?.SetTag("http.url", response.RequestMessage?.RequestUri?.ToString());
                activity?.SetTag("http.method", response.RequestMessage?.Method?.ToString());
                activity?.SetTag("http.status_code", (int)response.StatusCode);
                activity?.SetTag("http.content_type", response.Content.Headers.ContentType?.ToString());
                activity?.SetTag("http.content_length", response.Content.Headers.ContentLength?.ToString());

                var content = await response.Content.ReadAsStringAsync();
                activity?.SetTag("http.response_body", content);

                if (!response.IsSuccessStatusCode)
                {
                    activity?.SetStatus(ActivityStatusCode.Error);
                    activity?.AddEvent(new ActivityEvent("Erro ao chamar API de produtos"));
                    return [];
                }

                return JsonSerializer.Deserialize<List<ProdutoDto>>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }) ?? [];
            }
            catch (Exception ex)
            {
                activity?.SetStatus(ActivityStatusCode.Error);
                activity?.SetTag("exception.type", ex.GetType().Name);
                activity?.SetTag("exception.message", ex.Message);
                activity?.SetTag("exception.stacktrace", ex.StackTrace);
                activity?.AddEvent(new ActivityEvent("Exceção lançada na chamada HTTP"));

                return [];
            }
        }
    }
}