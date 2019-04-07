using Pizzaria.Domain.Models;
using System.Collections.Generic;

namespace Pizzaria.Domain.Repository.Interfaces
{
    public interface IAdicionaisPedidoRepository : IRepositoryBase<AdicionaisPedido>
    {
        /// <summary>
        /// Responsável por retornar todos as personalizações de um pedido.
        /// </summary>
        /// <param name="identificadorPedido">Identificador do pedido</param>
        /// <returns>Retorna as personalizações de um pedido</returns>
        IList<AdicionaisPedido> BuscarAdicionaisPorPedido(int identificadorPedido);

        /// <summary>
        /// Responsável por verificar a existência de um determinado adicional no pedido.
        /// </summary>
        /// <param name="identificadorPedido">Identificador do pedido</param>
        /// <param name="identificadorAdicional">Identificador do adicional</param>
        /// <returns>Retorna verdadeiro se o adicional existir no pedido</returns>
        bool ExisteAdicionalCadastroNoPedido(int identificadorPedido, int identificadorAdicional);
    }
}