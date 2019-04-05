using Pizzaria.Domain.Business.Dto;

namespace Pizzaria.Domain.Business.Interfaces
{
    public interface IResumoPedidoBusiness
    {
        ResumoPedidoDto ExibirResumoPedido(int identificadorPedido);
    }
}