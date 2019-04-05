using Pizzaria.Application.Services.Interfaces;
using Pizzaria.Application.ViewModels;
using Pizzaria.Domain.Business.Enums;

namespace Pizzaria.Application.Services
{
    public interface IPedidosService //: IServiceBase<PedidoViewModel>
    {
        void PersonalizarPedido(AdicionaisPizzaViewModel adicionalPizza);
    }
}