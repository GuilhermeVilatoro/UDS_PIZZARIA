using Pizzaria.Domain.Business.Dto;

namespace Pizzaria.Domain.Business.Interfaces
{
    public interface IMontagemPedidoBusiness
    {
        ResumoPedidoDto MontarPedido(MontagemPedidoDto montagemPedido);
    }
}