using Pizzaria.Domain.Models;
using System.Collections.Generic;

namespace Pizzaria.Domain.Repository.Interfaces
{
    public interface IAdicionaisPedidoRepository : IRepositoryBase<AdicionaisPedido>
    {
        IList<AdicionaisPedido> BuscarAdicionaisPorPedido(int identificadorPedido);

        bool ExisteAdicionalCadastroNoPedido(int identificadorPedido, int identificadorAdicional);
    }
}