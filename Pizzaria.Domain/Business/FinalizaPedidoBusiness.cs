using Pizzaria.Domain.Business.Interfaces;
using Pizzaria.Domain.Repository.Interfaces;
using System;

namespace Pizzaria.Domain.Business
{
    public class FinalizaPedidoBusiness : IFinalizaPedidoBusiness
    {
        private readonly IPedidoRepository _pedidoRepository;

        public FinalizaPedidoBusiness(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public void Finalizar(int identificadorPedido)
        {
            var pedido = _pedidoRepository.GetById(identificadorPedido);
            if (pedido == null)
                throw new Exception($"O pedido {identificadorPedido} não existe!");

            if (pedido.Finalizado.GetValueOrDefault(true))
                throw new Exception($"O pedido {identificadorPedido} já esta finalizado!");

            pedido.Finalizado = true;
            _pedidoRepository.Update(pedido);
        }
    }
}