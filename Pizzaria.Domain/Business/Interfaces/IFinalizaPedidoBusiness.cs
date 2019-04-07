namespace Pizzaria.Domain.Business.Interfaces
{
    public interface IFinalizaPedidoBusiness
    {
        /// <summary>
        /// Responsável por finalizar um pedido.
        /// </summary>
        /// <param name="identificadorPedido">Identificador do Pedido</param>
        void Finalizar(int identificadorPedido);
    }
}