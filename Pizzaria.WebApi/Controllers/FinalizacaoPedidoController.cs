using Microsoft.AspNetCore.Mvc;
using Pizzaria.Application.Services;
using Pizzaria.Application.ViewModels;

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

        // GET: api/FinalizacaoPedido/5
        [HttpGet("{id}")]
        public IActionResult GetResumoPedidoViewModel(int id)
        {
            var viewModel = _pedidosService.ExibirResumoPedido(id);

            return Response(viewModel);
        }

        // POST: api/FinalizacaoPedido
        [HttpPost]
        public IActionResult FinalizarPedido(int identificadorPedido)
        {
            if (!ModelState.IsValid)
                return Response();

            _pedidosService.FinalizarPedido(identificadorPedido);

            return Response();
        }        
    }
}