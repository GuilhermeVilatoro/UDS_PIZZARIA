using Pizzaria.Domain.Business.Dto;

namespace Pizzaria.Domain.Business.Interfaces
{
    public interface IResumoPedidoBusiness
    {
        /// <summary>
        /// Responsávek por exibir um resumo de um determinado pedido.
        /// </summary>
        /// <param name="identificadorPedido">Identificador do pedido</param>
        /// <returns>Retorna o pedido com os seus dados</returns>
        ResumoPedidoDto ExibirPedido(int identificadorPedido);
    }
}