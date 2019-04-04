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
    }
}