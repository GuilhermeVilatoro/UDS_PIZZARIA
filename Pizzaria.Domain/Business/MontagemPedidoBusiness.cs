using AutoMapper;
using Pizzaria.Domain.Business.Dto;
using Pizzaria.Domain.Business.Interfaces;
using Pizzaria.Domain.Models;
using Pizzaria.Domain.Repository.Interfaces;
using System;
using System.Linq;

namespace Pizzaria.Domain.Business
{
    public class MontagemPedidoBusiness : IMontagemPedidoBusiness
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly ISaboresPizzaRepository _saboresPizzaRepository;
        private readonly ITamanhosPizzaRepository _tamanhosPizzaRepository;

        private readonly IMapper _mapper;

        public MontagemPedidoBusiness(IPedidoRepository pedidoRepository,
            ISaboresPizzaRepository saboresPizzaRepository,
            ITamanhosPizzaRepository tamanhosPizzaRepository,
            IMapper mapper)
        {
            _pedidoRepository = pedidoRepository;
            _saboresPizzaRepository = saboresPizzaRepository;
            _tamanhosPizzaRepository = tamanhosPizzaRepository;

            _mapper = mapper;
        }

        public ResumoPedidoDto MontarPedido(MontagemPedidoDto montagemPedido)
        {
            var tamanhoPizza = _tamanhosPizzaRepository.GetAll()
                .FirstOrDefault(x => x.Tamanho.ToUpper() == montagemPedido.TamanhoPizza.ToUpper());

            if (tamanhoPizza == null)
                throw new Exception($"O tamanho de pizza { montagemPedido.TamanhoPizza } informado não esta cadastrado!");

            var saborPizza = _saboresPizzaRepository.GetAll()
                .FirstOrDefault(x => x.Sabor.ToUpper() == montagemPedido.SaborPizza.ToUpper());

            if (saborPizza == null)
                throw new Exception($"O sabor de pizza { montagemPedido.SaborPizza } informado não esta cadastrado!");

            var pedido = new Pedidos
            {
                TamanhosPizza = tamanhoPizza,
                SaboresPizza = saborPizza,
                Total = tamanhoPizza.Valor,
                Tempo = tamanhoPizza.Tempo + saborPizza.TempoAdicional ?? 0,
                Finalizado = false
            };

            _pedidoRepository.Add(pedido);

            var resumoPedido = _mapper.Map<ResumoPedidoDto>(pedido);
            return resumoPedido;
        }
    }
}