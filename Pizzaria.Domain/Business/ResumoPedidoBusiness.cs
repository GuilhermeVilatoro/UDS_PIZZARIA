using Pizzaria.Domain.Business.Interfaces;
using Pizzaria.Domain.Models;
using Pizzaria.Domain.Repository.Interfaces;
using System;

namespace Pizzaria.Domain.Business
{
    public class ResumoPedidoBusiness : IResumoPedidoBusiness
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly ITamanhosPizzaRepository _tamanhosPizzaRepository;
        private readonly ISaboresPizzaRepository _saboresPizzaRepository;

        public ResumoPedidoBusiness(IPedidoRepository pedidoRepository,
            ITamanhosPizzaRepository tamanhosPizzaRepository,
            ISaboresPizzaRepository saboresPizzaRepository)
        {
            _pedidoRepository = pedidoRepository;
            _tamanhosPizzaRepository = tamanhosPizzaRepository;
            _saboresPizzaRepository = saboresPizzaRepository;
        }

        public Pedidos ExibirPedido(int identificadorPedido)
        {
            var pedido = _pedidoRepository.GetById(identificadorPedido);
            if (pedido == null)
                throw new Exception($"O pedido {identificadorPedido} não existe!");

            pedido.TamanhoPizza = _tamanhosPizzaRepository.GetById(pedido.TamanhoPizzaId);
            pedido.SaborPizza = _saboresPizzaRepository.GetById(pedido.SaboresPizzaId);            

            return pedido;
        }      
    }
}