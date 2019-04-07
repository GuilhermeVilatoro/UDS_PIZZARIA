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
    public class MontagemPedidoBusinessTest
    {
        private IPedidoRepository pedidoRepository;
        private ISaboresPizzaRepository saboresPizzaRepository;
        private ITamanhosPizzaRepository tamanhosPizzaRepository;

        private IMapper mapper;

        private MontagemPedidoDto montagemPedidoDto;

        private TamanhosPizza tamanhoPizza;
        private SaboresPizza saborPizza;

        private const string PORTUGUESA = "portuguesa";
        private const string TAMANHOGRANDE = "grande";

        [SetUp]
        public void SetUp()
        {
            pedidoRepository = Substitute.For<IPedidoRepository>();
            saboresPizzaRepository = Substitute.For<ISaboresPizzaRepository>();
            tamanhosPizzaRepository = Substitute.For<ITamanhosPizzaRepository>();

            mapper = Substitute.For<IMapper>();

            montagemPedidoDto = Substitute.For<MontagemPedidoDto>();
            montagemPedidoDto.TamanhoPizza = TAMANHOGRANDE;
            montagemPedidoDto.SaborPizza = PORTUGUESA;

            tamanhoPizza = Substitute.For<TamanhosPizza>();
            tamanhoPizza.Tamanho = TAMANHOGRANDE;
            saborPizza = Substitute.For<SaboresPizza>();
            saborPizza.Sabor = PORTUGUESA;           
        }

        [Test]
        public void Deve_Retornar_Excecao_Ao_Montar_Um_Pedido_Informando_Um_Tamanho_Pizza_Inexistente()
        {
            Assert.Throws<Exception>(
                () => new MontagemPedidoBusiness(pedidoRepository, saboresPizzaRepository,
                   tamanhosPizzaRepository, mapper).MontarPedido(montagemPedidoDto),
                   "O pedido não deve ser criado!");
        }

        [Test]
        public void Deve_Retornar_Excecao_Ao_Montar_Um_Pedido_Informando_Um_Sabor_Pizza_Inexistente()
        {
            tamanhosPizzaRepository.GetAll().Returns(new List<TamanhosPizza> { tamanhoPizza });

            Assert.Throws<Exception>(
                () => new MontagemPedidoBusiness(pedidoRepository, saboresPizzaRepository,
                   tamanhosPizzaRepository, mapper).MontarPedido(montagemPedidoDto),
                   "O pedido não deve ser criado!");
        }

        [Test]
        public void Deve_Montar_Um_Pedido_Quando_Informado_Tamanho_E_Sabor_Pizza_Existentes()
        {
            tamanhosPizzaRepository.GetAll().Returns(new List<TamanhosPizza> { tamanhoPizza });
            saboresPizzaRepository.GetAll().Returns(new List<SaboresPizza> { saborPizza });

            new MontagemPedidoBusiness(pedidoRepository, saboresPizzaRepository,
                tamanhosPizzaRepository, mapper).MontarPedido(montagemPedidoDto);

            tamanhosPizzaRepository.ReceivedWithAnyArgs(1).GetAll();
            saboresPizzaRepository.ReceivedWithAnyArgs(1).GetAll();
            pedidoRepository.ReceivedWithAnyArgs(1).Add(Arg.Any<Pedidos>());
            mapper.ReceivedWithAnyArgs(1).Map<ResumoPedidoDto>(Arg.Any<Pedidos>());
        }
    }
}