using Pizzaria.Domain.Business.Dto;

namespace Pizzaria.Domain.Business.Interfaces
{
    public interface IMontagemPedidoBusiness
    {
        /// <summary>
        /// Responsável por montar o pedido inicial.
        /// </summary>
        /// <param name="montagemPedido">Montagem do pedido</param>
        /// <returns>Retorna o pedido gerado</returns>
        ResumoPedidoDto MontarPedido(MontagemPedidoDto montagemPedido);
    }
}