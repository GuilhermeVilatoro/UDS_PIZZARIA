using AutoMapper;
using Pizzaria.Application.ViewModels;
using Pizzaria.Domain.Models;

namespace Pizzaria.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<SaboresPizzaViewModel, SaboresPizza>();
            CreateMap<TamanhosPizzaViewModel, TamanhosPizza>();
            CreateMap<AdicionaisPizzaViewModel, AdicionaisPizza>();
            CreateMap<PedidoViewModel, Pedidos>();            
        }
    }
}