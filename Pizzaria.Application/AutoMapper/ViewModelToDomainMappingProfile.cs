using AutoMapper;
using Pizzaria.Application.ViewModels;
using Pizzaria.Domain.Models;

namespace Pizzaria.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<SaboresPizza, SaboresPizzaViewModel>();
            CreateMap<TamanhosPizza, TamanhosPizzaViewModel>();
            CreateMap<AdicionaisPizza, AdicionaisPizzaViewModel>();                      
        }
    }
}