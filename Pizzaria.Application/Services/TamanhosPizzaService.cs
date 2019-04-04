using AutoMapper;
using Pizzaria.Application.ViewModels;
using Pizzaria.Domain.Models;
using Pizzaria.Domain.Repository.Interfaces;

namespace Pizzaria.Application.Services
{
    public class TamanhosPizzaService : ServiceBase<TamanhosPizzaViewModel, TamanhosPizza>, ITamanhosPizzaService
    {
        public TamanhosPizzaService(IMapper mapper, IRepositoryBase<TamanhosPizza> repository) : base(mapper, repository)
        {
        }
    }
}