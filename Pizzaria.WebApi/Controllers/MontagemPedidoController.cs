using Microsoft.AspNetCore.Mvc;
using Pizzaria.Application.Services;
using Pizzaria.Application.ViewModels;
using System;

namespace Pizzaria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MontagemPedidoController : ApiController
    {
        private readonly IPedidosService _pedidosService;

        public MontagemPedidoController(IPedidosService pedidosService) : base()
        {
            _pedidosService = pedidosService;
        }

        // POST: api/MontagemPedido
        [HttpPost]
        public IActionResult MontarPedido(MontagemPedidoViewModel montagemPedidoViewModel)
        {
            if (!ModelState.IsValid)
                return Response(montagemPedidoViewModel);

            try
            {
                var pedidoViewModel = _pedidosService.MontarPedido(montagemPedidoViewModel);
                return Response(pedidoViewModel);
            }
            catch (Exception ex)
            {
                return new ObjectResult($"Erro ao montar o pedido: {ex.Message}");
            }
        }
    }
}