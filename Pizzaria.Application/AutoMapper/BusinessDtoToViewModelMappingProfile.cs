using AutoMapper;
using Pizzaria.Application.ViewModels;
using Pizzaria.Domain.Business.Dto;

namespace Pizzaria.Application.AutoMapper
{
    public class BusinessDtoToViewModelMappingProfile : Profile
    {
        public BusinessDtoToViewModelMappingProfile()
        {
            CreateMap<ResumoPedidoDto, PedidoViewModel>();           
        }
    }
}