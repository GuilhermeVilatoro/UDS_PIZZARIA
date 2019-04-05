using Pizzaria.Domain.Business.Dto;
using Pizzaria.Domain.Models;

namespace Pizzaria.Domain.Business.Interfaces
{
    public interface IMontagemPedidoBusiness
    {
        Pedidos MontarPedido(MontagemPedidoDto montagemPedido);
    }
}