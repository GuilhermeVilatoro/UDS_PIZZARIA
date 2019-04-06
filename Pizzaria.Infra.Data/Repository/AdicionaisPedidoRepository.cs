using System.Collections.Generic;
using System.Linq;
using Pizzaria.Domain.Models;
using Pizzaria.Infra.Data.Context;
using Pizzaria.Infra.Data.Repository;

namespace Pizzaria.Domain.Repository.Interfaces
{
    public class AdicionaisPedidoRepository : RepositoryBase<AdicionaisPedido>, IAdicionaisPedidoRepository
    {
        public AdicionaisPedidoRepository(PizzariaContext pizzariaContext) : base(pizzariaContext)
        {
        }

        public IList<AdicionaisPedido> BuscarAdicionaisPorPedido(int identificadorPedido)
        {
            return GetAll().Where(x => x.PedidosId == identificadorPedido).ToList();
        }

        public bool ExisteAdicionalCadastroNoPedido(int identificadorPedido, int identificadorAdicional)
        {
            return GetAll().Any(x => x.PedidosId == identificadorPedido && x.AdicionaisPizzaId == identificadorAdicional);
        }
    }
}