using AutoMapper;
using Pizzaria.Application.Services.Interfaces;
using Pizzaria.Application.ViewModels;
using Pizzaria.Domain.Models;
using Pizzaria.Domain.Repository.Interfaces;

namespace Pizzaria.Application.Services
{
    public class AdicionaisPizzaService : ServiceBase<AdicionaisPizzaViewModel, AdicionaisPizza>, IAdicionaisPizzaService
    {
        public AdicionaisPizzaService(IMapper mapper, IAdicionaisPizzaRepository repository) : base(mapper, repository)
        {
        }
    }
}