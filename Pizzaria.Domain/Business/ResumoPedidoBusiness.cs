using AutoMapper;
using Pizzaria.Domain.Business.Dto;
using Pizzaria.Domain.Business.Interfaces;
using Pizzaria.Domain.Repository.Interfaces;
using System;
using System.Linq;

namespace Pizzaria.Domain.Business
{
    public class ResumoPedidoBusiness : IResumoPedidoBusiness
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly ITamanhosPizzaRepository _tamanhosPizzaRepository;
        private readonly ISaboresPizzaRepository _saboresPizzaRepository;

        private readonly IMapper _mapper;

        public ResumoPedidoBusiness(IPedidoRepository pedidoRepository,
            ITamanhosPizzaRepository tamanhosPizzaRepository,
            ISaboresPizzaRepository saboresPizzaRepository,
            IMapper mapper)
        {
            _pedidoRepository = pedidoRepository;
            _tamanhosPizzaRepository = tamanhosPizzaRepository;
            _saboresPizzaRepository = saboresPizzaRepository;

            _mapper = mapper;
        }

        public ResumoPedidoDto ExibirPedido(int identificadorPedido)
        {
            var pedido = _pedidoRepository.GetById(identificadorPedido);
            if (pedido == null)
                throw new Exception($"O pedido {identificadorPedido} não existe!");                     

            pedido.TamanhosPizza = _tamanhosPizzaRepository.GetById(pedido.TamanhosPizzaId);
            pedido.SaboresPizza = _saboresPizzaRepository.GetById(pedido.SaboresPizzaId);

            var resumoPedido = _mapper.Map<ResumoPedidoDto>(pedido);           

            return resumoPedido;
        }      
    }
}