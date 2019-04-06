using Pizzaria.Domain.Business.Dto;
using Pizzaria.Domain.Business.Interfaces;
using Pizzaria.Domain.Models;
using Pizzaria.Domain.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pizzaria.Domain.Business
{
    public class PersonalizacaoPedidoBusiness : IPersonalizacaoPedidoBusiness
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IAdicionaisPizzaRepository _adicionaisPizzaRepository;
        private readonly ITamanhosPizzaRepository _tamanhosPizzaRepository;
        private readonly ISaboresPizzaRepository _saboresPizzaRepository;

        public PersonalizacaoPedidoBusiness(IPedidoRepository pedidoRepository,
            IAdicionaisPizzaRepository adicionaisPizzaRepository,
            ITamanhosPizzaRepository tamanhosPizzaRepository,
            ISaboresPizzaRepository saboresPizzaRepository)
        {
            _adicionaisPizzaRepository = adicionaisPizzaRepository;
            _tamanhosPizzaRepository = tamanhosPizzaRepository;
            _saboresPizzaRepository = saboresPizzaRepository;
            _pedidoRepository = pedidoRepository;
        }

        public Pedidos PersonalizarPedido(PersonalizacaoPedidoDto personalizacaoPedido)
        {
            var identificadorPedido = personalizacaoPedido.IdentificadorPedido;

            var pedido = _pedidoRepository.GetById(personalizacaoPedido.IdentificadorPedido);
            if (pedido == null)
                throw new Exception($"O pedido {identificadorPedido} não existe!");

            if (pedido.Finalizado.GetValueOrDefault(true))
                throw new Exception($"O pedido já está finalizado não é possível adicional incrementos!");

            var adicionalPizza = personalizacaoPedido.AdicionalPizza;

            var personalizacaoPizza = _adicionaisPizzaRepository.GetAll()
                .FirstOrDefault(x => x.Adicional.ToUpper() == adicionalPizza.ToUpper());

            if (personalizacaoPizza == null)
                throw new Exception($"A personalização {adicionalPizza} informada não está cadastrada!");

            pedido.Total += personalizacaoPizza.Valor ?? 0;
            pedido.Tempo += personalizacaoPizza.Tempo ?? 0;
            pedido.TamanhoPizza = _tamanhosPizzaRepository.GetById(pedido.TamanhoPizzaId);
            pedido.SaborPizza = _saboresPizzaRepository.GetById(pedido.SaboresPizzaId);

            if (pedido.AdicionaisPedido == null)
                pedido.AdicionaisPedido = new List<AdicionaisPedido>();

            pedido.AdicionaisPedido.Add(new AdicionaisPedido
            {
                AdicionalPizza = personalizacaoPizza,
                AdicionaisPizzaId = personalizacaoPizza.Id,
                Pedido = pedido,
                PedidosId = pedido.Id                
            });

            _pedidoRepository.Update(pedido);
            return pedido;
        }
    }
}