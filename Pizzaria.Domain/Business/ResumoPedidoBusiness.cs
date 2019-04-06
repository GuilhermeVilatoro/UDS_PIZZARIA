using AutoMapper;
using Pizzaria.Domain.Business.Dto;
using Pizzaria.Domain.Business.Interfaces;
using Pizzaria.Domain.Repository.Interfaces;
using System;

namespace Pizzaria.Domain.Business
{
    public class ResumoPedidoBusiness : IResumoPedidoBusiness
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly ITamanhosPizzaRepository _tamanhosPizzaRepository;
        private readonly ISaboresPizzaRepository _saboresPizzaRepository;
        private readonly IAdicionaisPedidoRepository _adicionaisPedidoRepository;
        private readonly IAdicionaisPizzaRepository _adicionaisPizzaRepository;

        private readonly IMapper _mapper;

        public ResumoPedidoBusiness(IPedidoRepository pedidoRepository,
            ITamanhosPizzaRepository tamanhosPizzaRepository,
            ISaboresPizzaRepository saboresPizzaRepository,
            IAdicionaisPedidoRepository adicionaisPedidoRepository,
            IAdicionaisPizzaRepository adicionaisPizzaRepository,
            IMapper mapper)
        {
            _pedidoRepository = pedidoRepository;
            _tamanhosPizzaRepository = tamanhosPizzaRepository;
            _saboresPizzaRepository = saboresPizzaRepository;
            _adicionaisPedidoRepository = adicionaisPedidoRepository;
            _adicionaisPizzaRepository = adicionaisPizzaRepository;
            _mapper = mapper;
        }

        public ResumoPedidoDto ExibirPedido(int identificadorPedido)
        {
            var pedido = _pedidoRepository.GetById(identificadorPedido);
            if (pedido == null)
                throw new Exception($"O pedido {identificadorPedido} não existe!");                     

            pedido.TamanhosPizza = _tamanhosPizzaRepository.GetById(pedido.TamanhosPizzaId);
            pedido.SaboresPizza = _saboresPizzaRepository.GetById(pedido.SaboresPizzaId);
            pedido.AdicionaisPedido = 
                _adicionaisPedidoRepository.BuscarAdicionaisPorPedido(identificadorPedido);

            foreach (var adicional in pedido.AdicionaisPedido)
                adicional.AdicionaisPizza = _adicionaisPizzaRepository.GetById(adicional.AdicionaisPizzaId);

            var resumoPedido = _mapper.Map<ResumoPedidoDto>(pedido);           

            return resumoPedido;
        }      
    }
}