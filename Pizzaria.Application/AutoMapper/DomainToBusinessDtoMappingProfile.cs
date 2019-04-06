using AutoMapper;
using Pizzaria.Domain.Business.Dto;
using Pizzaria.Domain.Models;
using System.Linq;

namespace Pizzaria.Application.AutoMapper
{
    public class DomainToBusinessDtoMappingProfile : Profile
    {
        public DomainToBusinessDtoMappingProfile()
        {
            CreateMap<Pedidos, ResumoPedidoDto>()
                .ForMember(dest => dest.TamanhoPizza, opt => opt.MapFrom(src => src.TamanhosPizza.Tamanho))
                .ForMember(dest => dest.SaborPizza, opt => opt.MapFrom(src => src.SaboresPizza.Sabor))
                .ForMember(dest => dest.Personalizacoes, opt => opt.MapFrom(src => src.AdicionaisPedido != null
                   ? src.AdicionaisPedido.Select(ap => ap.AdicionaisPizza) : null));
        }
    }
}