using AutoMapper;
using NSubstitute;
using NUnit.Framework;
using Pizzaria.Domain.Business;
using Pizzaria.Domain.Business.Dto;
using Pizzaria.Domain.Models;
using Pizzaria.Domain.Repository.Interfaces;
using System;
using System.Collections.Generic;

namespace Pizzaria.Domain.UnitTests.Business
{
    public class ResumoPedidoBusinessTest
    {
        private IPedidoRepository pedidoRepository;
        private ITamanhosPizzaRepository tamanhosPizzaRepository;
        private ISaboresPizzaRepository saboresPizzaRepository;
        private IAdicionaisPedidoRepository adicionaisPedidoRepository;
        private IAdicionaisPizzaRepository adicionaisPizzaRepository;

        private IMapper mapper;

        [SetUp]
        public void SetUp()
        {
            pedidoRepository = Substitute.For<IPedidoRepository>();
            tamanhosPizzaRepository = Substitute.For<ITamanhosPizzaRepository>();
            saboresPizzaRepository = Substitute.For<ISaboresPizzaRepository>();
            adicionaisPizzaRepository = Substitute.For<IAdicionaisPizzaRepository>();
            adicionaisPedidoRepository = Substitute.For<IAdicionaisPedidoRepository>();

            mapper = Substitute.For<IMapper>();
        }

        [Test]
        public void Deve_Retornar_Excecao_Ao_Tentar_Exibir_Um_Pedido_Inexistente()
        {
            Assert.Throws<Exception>(
                () => new ResumoPedidoBusiness(pedidoRepository, tamanhosPizzaRepository, saboresPizzaRepository,
                adicionaisPedidoRepository, adicionaisPizzaRepository, mapper).ExibirPedido(1),
                "O pedido não deve ser exibido!");
        }

        [Test]
        public void Deve_Retornar_O_Resumo_Do_Pedido_Dado_Um_Pedido()
        {
            var pedido = Substitute.For<Pedidos>();            
            var adicionalPedido = Substitute.For<AdicionaisPedido>();           

            var adicionaisPedido = Substitute.For<List<AdicionaisPedido>>();
            adicionaisPedido.Add(adicionalPedido);

            pedidoRepository.GetById(Arg.Any<int>()).Returns(pedido);
            adicionaisPedidoRepository.BuscarAdicionaisPorPedido(Arg.Any<int>()).Returns(adicionaisPedido);           

            new ResumoPedidoBusiness(pedidoRepository, tamanhosPizzaRepository, saboresPizzaRepository,
                adicionaisPedidoRepository, adicionaisPizzaRepository, mapper).ExibirPedido(1);

            pedidoRepository.ReceivedWithAnyArgs(1).GetById(Arg.Any<int>());
            tamanhosPizzaRepository.ReceivedWithAnyArgs(1).GetById(Arg.Any<int>());
            saboresPizzaRepository.ReceivedWithAnyArgs(1).GetById(Arg.Any<int>());
            adicionaisPedidoRepository.ReceivedWithAnyArgs(1).BuscarAdicionaisPorPedido(Arg.Any<int>());
            adicionaisPizzaRepository.ReceivedWithAnyArgs(1).GetById(Arg.Any<int>());
            mapper.ReceivedWithAnyArgs(1).Map<ResumoPedidoDto>(Arg.Any<Pedidos>());
        }      
    }
}