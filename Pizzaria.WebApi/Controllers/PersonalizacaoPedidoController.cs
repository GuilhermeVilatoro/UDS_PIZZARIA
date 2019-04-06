using Microsoft.AspNetCore.Mvc;
using Pizzaria.Application.Services;
using Pizzaria.Application.ViewModels;
using System;

namespace Pizzaria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalizacaoPedidoController : ApiController
    {
        private readonly IPedidosService _pedidosService;

        public PersonalizacaoPedidoController(IPedidosService pedidosService) : base()
        {
            _pedidosService = pedidosService;
        }

        // POST: api/PersonalizacaoPedido
        [HttpPost]
        public IActionResult PersonalizarPedido(PersonalizacaoPedidoViewModel personalizacaoPedidoViewModel)
        {
            if (!ModelState.IsValid)
                return Response(personalizacaoPedidoViewModel);

            try
            {
                var pedidoViewModel = _pedidosService.PersonalizarPedido(personalizacaoPedidoViewModel);
                return Response(pedidoViewModel);
            }
            catch (Exception ex)
            {
                return new ObjectResult($"Erro ao personalizar o pedido: {ex.Message}");
            }
        }
    }
}