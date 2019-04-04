using Pizzaria.Domain.Models;
using Pizzaria.Infra.Data.Context;
using Pizzaria.Infra.Data.Repository;

namespace Pizzaria.Domain.Repository.Interfaces
{
    public class TamanhosPizzaRepository : RepositoryBase<TamanhosPizza>, ITamanhosPizzaRepository
    {
        public TamanhosPizzaRepository(PizzariaContext pizzariaContext) : base(pizzariaContext)
        {
        }
    }
}