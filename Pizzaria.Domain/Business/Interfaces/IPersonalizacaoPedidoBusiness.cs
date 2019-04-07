using Pizzaria.Domain.Business.Dto;

namespace Pizzaria.Domain.Business.Interfaces
{
    public interface IPersonalizacaoPedidoBusiness
    {
        /// <summary>
        /// Responsável por personalizar um pedido que não esteja finalizado.
        /// </summary>
        /// <param name="personalizacaoPedido">Item que será personalizado ao pedido</param>
        /// <returns>Retorno o pedido com a personalização</returns>
        ResumoPedidoDto PersonalizarPedido(PersonalizacaoPedidoDto personalizacaoPedido);
    }
}