using Pizzaria.Domain.Business.Dto;
using Pizzaria.Domain.Business.Interfaces;
using Pizzaria.Domain.Models;
using Pizzaria.Domain.Repository.Interfaces;
using System;
using System.Linq;

namespace Pizzaria.Domain.Business
{
    public class PersonalizacaoPedidoBusiness : IPersonalizacaoPedidoBusiness
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IAdicionaisPizzaRepository _adicionaisPizzaRepository;

        public PersonalizacaoPedidoBusiness(IAdicionaisPizzaRepository adicionaisPizzaRepository,
            IPedidoRepository pedidoRepository)
        {
            _adicionaisPizzaRepository = adicionaisPizzaRepository;
            _pedidoRepository = pedidoRepository;
        }       

        public Pedidos PersonalizarPedido(PersonalizacaoPedidoDto personalizacaoPedido)
        {
            var identificadorPedido = personalizacaoPedido.IdentificadorPedido;

            var pedido = _pedidoRepository.GetById(personalizacaoPedido.IdentificadorPedido);
            if (pedido == null)
                throw new Exception($"O pedido com {identificadorPedido} não existe!");

            if (pedido.Finalizado.GetValueOrDefault(true))
                throw new Exception($"O pedido já está finalizado não é possível adicional incrementos!");

            var adicionalPizza = personalizacaoPedido.AdicionalPizza;

            var personalizacaoPizza = _adicionaisPizzaRepository.GetAll()
                .FirstOrDefault(x => x.Adicional.ToUpper() == adicionalPizza.ToUpper());

            if (personalizacaoPizza == null)
                throw new Exception($"A personalização {adicionalPizza} informada não está cadastrada!");

            var teste = pedido.AdicionaisPedido;
            pedido.Total += personalizacaoPizza.Valor ?? 0;
            pedido.Tempo += personalizacaoPizza.Tempo ?? 0;

            _pedidoRepository.Update(pedido);
            return pedido;
        }
    }
}