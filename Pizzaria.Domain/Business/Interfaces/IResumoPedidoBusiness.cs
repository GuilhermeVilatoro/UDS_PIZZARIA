using Pizzaria.Domain.Business.Dto;

namespace Pizzaria.Domain.Business.Interfaces
{
    public interface IResumoPedidoBusiness
    {
        ResumoPedidoDto ExibirPedido(int identificadorPedido);
    }
}