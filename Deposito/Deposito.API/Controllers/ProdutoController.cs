using Deposito.Application.CasosDeUso.Produto;
using Microsoft.AspNetCore.Mvc;

namespace Deposito.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly ConsultarProdutoUseCase _consultarProdutoUseCase;

        public ProdutoController(ConsultarProdutoUseCase consultarProdutoUseCase)
        {
            _consultarProdutoUseCase = consultarProdutoUseCase;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var produto = await _consultarProdutoUseCase.ExecuteAsync(id);

            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodos()
        {
            var produtos = await _consultarProdutoUseCase.ExecuteTodosAsync();
            return Ok(produtos);
        }
    }
}
