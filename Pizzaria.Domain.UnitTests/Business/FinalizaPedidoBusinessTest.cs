using NSubstitute;
using NUnit.Framework;
using Pizzaria.Domain.Business;
using Pizzaria.Domain.Models;
using Pizzaria.Domain.Repository.Interfaces;
using System;

namespace Pizzaria.Domain.UnitTests.Business
{
    public class FinalizaPedidoBusinessTest
    {
        private IPedidoRepository pedidoRepository;
        private Pedidos pedido;

        [SetUp]
        public void SetUp()
        {
            pedidoRepository = Substitute.For<IPedidoRepository>();
            pedido = Substitute.For<Pedidos>();
            pedido.Finalizado = false;
        }

        [Test]
        public void Deve_Retornar_Excecao_Quando_Finalizar_Um_Pedido_Inexistente()
        {            
            Assert.Throws<Exception>(
                () => new FinalizaPedidoBusiness(pedidoRepository).Finalizar(1),
                "O pedido não deve ser finalizado!");
        }

        [Test]
        public void Deve_Retornar_Excecao_Quando_Finalizar_Um_Pedido_Ja_Finalizado()
        {
            pedido.Finalizado = true;
            pedidoRepository.GetById(1).Returns(pedido);

            Assert.Throws<Exception>(
               () => new FinalizaPedidoBusiness(pedidoRepository).Finalizar(1),
               "Um pedido já finalizado não deve ser finalizado!");
        }

        [Test]
        public void Deve_Finalizar_Um_Pedido_Aberto()
        {
            pedidoRepository.GetById(1).Returns(pedido);

            new FinalizaPedidoBusiness(pedidoRepository).Finalizar(1);

            pedidoRepository.ReceivedWithAnyArgs(1).Update(Arg.Any<Pedidos>());            
        }
    }
}