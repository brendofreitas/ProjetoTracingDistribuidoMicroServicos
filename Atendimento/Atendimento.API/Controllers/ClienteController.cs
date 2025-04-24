using Atendimento.Application.Services;
using Atendimento.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Atendimento.API.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteService _clienteService;

        public ClienteController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public async Task<IActionResult> Index()
        {
            var clientes = await _clienteService.ObterTodos();
            return View(clientes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            if (!ModelState.IsValid)
                return View(cliente);

            await _clienteService.Adicionar(cliente);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var cliente = await _clienteService.ObterPorIdComPedidosEInteracoes(id);
            if (cliente is null)
                return NotFound();

            return View(cliente);
        }
    }
}
