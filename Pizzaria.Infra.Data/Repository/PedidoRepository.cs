using Pizzaria.Domain.Models;
using Pizzaria.Infra.Data.Context;
using Pizzaria.Infra.Data.Repository;

namespace Pizzaria.Domain.Repository.Interfaces
{
    public class PedidoRepository : RepositoryBase<Pedidos>, IPedidoRepository
    {
        public PedidoRepository(PizzariaContext pizzariaContext) : base(pizzariaContext)
        {
        }
    }
}