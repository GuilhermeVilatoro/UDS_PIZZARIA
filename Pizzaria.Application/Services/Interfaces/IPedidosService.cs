using Pizzaria.Application.ViewModels;

namespace Pizzaria.Application.Services
{
    public interface IPedidosService
    {
        /// <summary>
        /// Responsavel por montar o pedido na aplicação.
        /// </summary>
        /// <param name="montagemPedido">Montagem do pedido</param>
        /// <returns>Retorna o pedido para aplicação</returns>
        PedidoViewModel MontarPedido(MontagemPedidoViewModel montagemPedido);

        /// <summary>
        /// Responsável por personalizar o pedido com o adicional informado pela aplicação.
        /// </summary>
        /// <param name="personalizacaoPedido">Personlaização do pedido aplicação</param>
        /// <returns>Retorna o pedido personalizado para aplicação</returns>
        PedidoViewModel PersonalizarPedido(PersonalizacaoPedidoViewModel personalizacaoPedido);

        /// <summary>
        /// Responsável por exibir o pedido para aplicação.
        /// </summary>
        /// <param name="identificadorPedido">Identificador do pedido</param>
        /// <returns>Retorna os dados do pedido para aplicação</returns>
        PedidoViewModel ExibirPedido(int identificadorPedido);

        /// <summary>
        /// Responsável por finalizar o pedido.
        /// </summary>
        /// <param name="identificadorPedido">Identificador do pedido</param>
        void FinalizarPedido(int identificadorPedido);
    }
}