using Pizzaria.Domain.Models;
using Pizzaria.Infra.Data.Context;
using Pizzaria.Infra.Data.Repository;

namespace Pizzaria.Domain.Repository.Interfaces
{
    public class SaboresPizzaRepository : RepositoryBase<SaboresPizza>, ISaboresPizzaRepository
    {
        public SaboresPizzaRepository(PizzariaContext pizzariaContext) : base(pizzariaContext)
        {
        }
    }
}