﻿using Atendimento.Application.CasoDeUso.Pedido;
using Atendimento.Application.Interfaces;
using Atendimento.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Atendimento.API.Controllers
{
    public class AtendimentoController(CriarPedidoUseCase _criarPedidoUseCase, IDepositoService _depositoApiClient) : Controller
    {
        private static readonly ActivitySource ActivitySource = new("Atendimento.Controller");
        public async Task<IActionResult> Index()
        {
            using var activity = ActivitySource.StartActivity("ListarProdutos");

            var produtos = await _depositoApiClient.ObterProdutosAsync();

            activity?.SetTag("produtos.quantidade", produtos.Count());
            activity?.SetTag("produtos.exibidos", produtos.Select(p => p.Nome).ToList());

            return View(produtos);
        }


        [HttpPost]
        public async Task<IActionResult> Comprar(int produtoId)
        {
            // Simulando um cliente logado. Na prática, você deve obter o ID do cliente logado.
            var clienteId = 1;
            var nomeProduto = $"Produto {produtoId}";
            var precoProduto = 99.90m;

            var itens = new List<ItemPedido>
            {
                new ItemPedido
                {
                    ProdutoId = produtoId,
                    NomeProduto = nomeProduto,
                    PrecoUnitario = precoProduto,
                    Quantidade = 1
                }
            };

            try
            {
                await _criarPedidoUseCase.ExecuteAsync(clienteId, itens);
                TempData["Mensagem"] = $"Produto '{nomeProduto}' comprado com sucesso!";
            }
            catch (Exception ex)
            {
                TempData["Mensagem"] = $"Erro ao comprar produto: {ex.Message}";
            }

            return RedirectToAction("Index");
        }
    }
}
