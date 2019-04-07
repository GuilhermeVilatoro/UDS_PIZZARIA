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
    public class PersonalizacaoPedidoBusinessTest
    {
        private IPedidoRepository pedidoRepository;
        private IAdicionaisPizzaRepository adicionaisPizzaRepository;
        private ITamanhosPizzaRepository tamanhosPizzaRepository;
        private ISaboresPizzaRepository saboresPizzaRepository;
        private IAdicionaisPedidoRepository adicionaisPedidoRepository;

        private IMapper mapper;

        private PersonalizacaoPedidoDto personalizacaoPedidoDto;

        private Pedidos pedido;
        private AdicionaisPizza adicionalPizza;

        [SetUp]
        public void SetUp()
        {
            pedidoRepository = Substitute.For<IPedidoRepository>();
            adicionaisPizzaRepository = Substitute.For<IAdicionaisPizzaRepository>();
            tamanhosPizzaRepository = Substitute.For<ITamanhosPizzaRepository>();
            saboresPizzaRepository = Substitute.For<ISaboresPizzaRepository>();
            adicionaisPedidoRepository = Substitute.For<IAdicionaisPedidoRepository>();

            mapper = Substitute.For<IMapper>();
            personalizacaoPedidoDto = Substitute.For<PersonalizacaoPedidoDto>();
            personalizacaoPedidoDto.IdentificadorPedido = 1;
            personalizacaoPedidoDto.AdicionalPizza = "extra bacon";            

            pedido = Substitute.For<Pedidos>();
            pedido.Id = personalizacaoPedidoDto.IdentificadorPedido;
            pedido.Finalizado = false;

            adicionalPizza = Substitute.For<AdicionaisPizza>();
            adicionalPizza.Id = 1;
            adicionalPizza.Adicional = personalizacaoPedidoDto.AdicionalPizza;
            adicionalPizza.Valor = 3;
            adicionalPizza.Tempo = 0;
        }

        [Test]
        public void Deve_Retornar_Excecao_Ao_Personalizar_Um_Pedido_Inexistente()
        {
            Assert.Throws<Exception>(
                () => new PersonalizacaoPedidoBusiness(pedidoRepository, adicionaisPizzaRepository,
                tamanhosPizzaRepository, saboresPizzaRepository, adicionaisPedidoRepository, mapper).PersonalizarPedido(personalizacaoPedidoDto),
                   "Não deve ser possível adicionar a personalização ao pedido!");
        }

        [Test]
        public void Deve_Retornar_Excecao_Ao_Personalizar_Um_Pedido_Finalizado()
        {
            pedido.Finalizado = true;
            pedidoRepository.GetById(Arg.Any<int>()).Returns(pedido);

            Assert.Throws<Exception>(
                () => new PersonalizacaoPedidoBusiness(pedidoRepository, adicionaisPizzaRepository,
                tamanhosPizzaRepository, saboresPizzaRepository, adicionaisPedidoRepository, mapper).PersonalizarPedido(personalizacaoPedidoDto),
                   "Não deve ser possível adicionar a personalização ao pedido!");
        }

        [Test]
        public void Deve_Retornar_Excecao_Ao_Personalizar_Um_Pedido_Com_Personalizacao_Inexistente()
        {
            pedidoRepository.GetById(Arg.Any<int>()).Returns(pedido);           

            Assert.Throws<Exception>(
                () => new PersonalizacaoPedidoBusiness(pedidoRepository, adicionaisPizzaRepository,
                tamanhosPizzaRepository, saboresPizzaRepository, adicionaisPedidoRepository, mapper).PersonalizarPedido(personalizacaoPedidoDto),
                   "Não deve ser possível adicionar a personalização ao pedido!");
        }

        [Test]
        public void Deve_Retornar_Excecao_Ao_Personalizar_Um_Pedido_Com_Personalizacao_Ja_Adicionada_No_Pedido()
        {
            pedidoRepository.GetById(Arg.Any<int>()).Returns(pedido);
            adicionaisPizzaRepository.GetAll().Returns(new List<AdicionaisPizza> { adicionalPizza });
            adicionaisPedidoRepository.ExisteAdicionalCadastroNoPedido(Arg.Any<int>(), Arg.Any<int>()).Returns(true);

            Assert.Throws<Exception>(
                () => new PersonalizacaoPedidoBusiness(pedidoRepository, adicionaisPizzaRepository,
                tamanhosPizzaRepository, saboresPizzaRepository, adicionaisPedidoRepository, mapper).PersonalizarPedido(personalizacaoPedidoDto),
                   "Não deve ser possível adicionar a personalização ao pedido!");
        }      

        [Test]
        public void Deve_Personalizar_Um_Pedido_Quando_Informado_Personalizacao_Cadastrada_Que_Nao_Exista_No_Pedido()
        {
            pedidoRepository.GetById(Arg.Any<int>()).Returns(pedido);
            adicionaisPizzaRepository.GetAll().Returns(new List<AdicionaisPizza> { adicionalPizza });
            adicionaisPedidoRepository.ExisteAdicionalCadastroNoPedido(Arg.Any<int>(), Arg.Any<int>()).Returns(false);

            new PersonalizacaoPedidoBusiness(pedidoRepository, adicionaisPizzaRepository,
                tamanhosPizzaRepository, saboresPizzaRepository, adicionaisPedidoRepository, mapper).PersonalizarPedido(personalizacaoPedidoDto);            

            tamanhosPizzaRepository.ReceivedWithAnyArgs(1).GetById(Arg.Any<int>());
            saboresPizzaRepository.ReceivedWithAnyArgs(1).GetById(Arg.Any<int>());
            adicionaisPedidoRepository.ReceivedWithAnyArgs(1).BuscarAdicionaisPorPedido(Arg.Any<int>());
            pedidoRepository.ReceivedWithAnyArgs(1).Update(Arg.Any<Pedidos>());
            mapper.ReceivedWithAnyArgs(1).Map<ResumoPedidoDto>(Arg.Any<Pedidos>());
        }       
    }
}