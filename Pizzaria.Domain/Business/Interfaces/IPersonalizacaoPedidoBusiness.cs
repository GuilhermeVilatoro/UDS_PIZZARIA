using Pizzaria.Domain.Business.Dto;

namespace Pizzaria.Domain.Business.Interfaces
{
    public interface IPersonalizacaoPedidoBusiness
    {
        ResumoPedidoDto PersonalizarPedido(PersonalizacaoPedidoDto personalizacaoPedido);
    }
}