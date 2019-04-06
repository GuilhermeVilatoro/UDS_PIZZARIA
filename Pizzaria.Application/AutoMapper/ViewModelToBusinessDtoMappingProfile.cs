using AutoMapper;
using Pizzaria.Application.ViewModels;
using Pizzaria.Domain.Business.Dto;

namespace Pizzaria.Application.AutoMapper
{
    public class ViewModelToBusinessDtoMappingProfile : Profile
    {
        public ViewModelToBusinessDtoMappingProfile()
        {
            CreateMap<MontagemPedidoDto, MontagemPedidoViewModel>();
            CreateMap<PersonalizacaoPedidoDto, PersonalizacaoPedidoViewModel>();            
        }
    }
}