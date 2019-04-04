using Pizzaria.Domain.Models;
using Pizzaria.Infra.Data.Context;
using Pizzaria.Infra.Data.Repository;

namespace Pizzaria.Domain.Repository.Interfaces
{
    public class AdicionaisPizzaRepository : RepositoryBase<AdicionaisPizza>, IAdicionaisPizzaRepository
    {
        public AdicionaisPizzaRepository(PizzariaContext pizzariaContext) : base(pizzariaContext)
        {
        }
    }
}