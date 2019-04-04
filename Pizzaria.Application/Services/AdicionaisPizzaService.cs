using AutoMapper;
using Pizzaria.Application.ViewModels;
using Pizzaria.Domain.Models;
using Pizzaria.Domain.Repository.Interfaces;

namespace Pizzaria.Application.Services
{
    public class AdicionaisPizzaService : ServiceBase<AdicionaisPizzaViewModel, AdicionaisPizza>, IAdicionaisPizzaService
    {
        public AdicionaisPizzaService(IMapper mapper, IRepositoryBase<AdicionaisPizza> repository) : base(mapper, repository)
        {
        }
    }
}