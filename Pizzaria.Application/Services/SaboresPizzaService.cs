using AutoMapper;
using Pizzaria.Application.ViewModels;
using Pizzaria.Domain.Models;
using Pizzaria.Domain.Repository.Interfaces;

namespace Pizzaria.Application.Services
{
    public class SaboresPizzaService : ServiceBase<SaboresPizzaViewModel, SaboresPizza>, ISaboresPizzaService
    {
        public SaboresPizzaService(IMapper mapper, ISaboresPizzaRepository repository) : base(mapper, repository)
        {
        }
    }
}