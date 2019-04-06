using Pizzaria.Domain.Business.Dto;
using Pizzaria.Domain.Models;

namespace Pizzaria.Domain.Business.Interfaces
{
    public interface IResumoPedidoBusiness
    {
        Pedidos ExibirPedido(int identificadorPedido);
    }
}