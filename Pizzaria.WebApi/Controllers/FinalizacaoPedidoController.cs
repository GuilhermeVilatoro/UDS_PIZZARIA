using Microsoft.AspNetCore.Mvc;
using Pizzaria.Application.Services;
using System;

namespace Pizzaria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinalizacaoPedidoController : ApiController
    {
        private readonly IPedidosService _pedidosService;

        public FinalizacaoPedidoController(IPedidosService pedidosService) : base()
        {
            _pedidosService = pedidosService;
        }

        // GET: api/Pedido/5
        [HttpGet("{id}")]
        public IActionResult GetPedidoViewModel(int id)
        {
            try
            {
                var viewModel = _pedidosService.ExibirPedido(id);
                return Response(viewModel);
            }
            catch (Exception ex)
            {
                return new ObjectResult($"Erro ao exibir o pedido: {ex.Message}");
            }
        }

        // POST: api/FinalizacaoPedido
        [HttpPost]
        public IActionResult FinalizarPedido(int identificadorPedido)
        {
            if (!ModelState.IsValid)
                return Response();

            try
            {
                _pedidosService.FinalizarPedido(identificadorPedido);
                return new ObjectResult($"O pedido finalizado com sucesso!");
            }
            catch (Exception ex)
            {
                return new ObjectResult($"Erro ao finalizar o pedido: {ex.Message}");
            }          
        }
    }
}