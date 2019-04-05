using Microsoft.AspNetCore.Mvc;
using Pizzaria.Application.Services;
using Pizzaria.Application.ViewModels;
using Pizzaria.Domain.Business.Enums;

namespace Pizzaria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ApiController
    {
        private readonly IPedidosService _pedidosService;

        public PedidoController(IPedidosService pedidosService) : base()
        {
            _pedidosService = pedidosService;
        }

        //// GET: api/Pedido
        //[HttpGet]
        //public IActionResult GetPedidoViewModel()
        //{
        //    return Response(_pedidosService.GetAll());
        //}

        //// GET: api/Pedido/5
        //[HttpGet("{id}")]
        //public IActionResult GetPedidoViewModel(int id)
        //{
        //    var viewModel = _pedidosService.GetById(id);

        //    return Response(viewModel);
        //}

        // PUT: api/Pedido/5
        //[HttpPut("{id}")]
        //public IActionResult PutPedidoViewModel([FromBody]PedidoViewModel pedidoViewModel)
        //{
        //    if (!ModelState.IsValid)
        //        return Response(pedidoViewModel);

        //    _pedidosService.Update(pedidoViewModel);

        //    return Response(pedidoViewModel);
        //}

        // POST: api/Pedido
        [HttpPost]
        public IActionResult PostPedidoViewModel(AdicionaisPizzaViewModel pedidoViewModel)
        {
            if (!ModelState.IsValid)
                return Response(pedidoViewModel);

            _pedidosService.PersonalizarPedido(pedidoViewModel);

            return Response(pedidoViewModel);
        }

        //// DELETE: api/Pedido/5
        //[HttpDelete("{id}")]
        //public IActionResult DeletePedidoViewModel(int id)
        //{
        //    _pedidosService.Delete(id);

        //    return Response();
        //}
    }
}
