using Microsoft.AspNetCore.Mvc;
using Pizzaria.Application.Services;
using Pizzaria.Application.ViewModels;

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

            var pedidoViewModel = _pedidosService.MontarPedido(montagemPedidoViewModel);

            return Response(pedidoViewModel);
        }        
    }
}