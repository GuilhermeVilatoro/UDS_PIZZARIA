using Pizzaria.Domain.Business.Dto;
using Pizzaria.Domain.Business.Interfaces;
using Pizzaria.Domain.Models;
using Pizzaria.Domain.Repository.Interfaces;
using System;
using System.Collections.Generic;

namespace Pizzaria.Domain.Business
{
    public class ResumoPedidoBusiness : IResumoPedidoBusiness
    {
        private readonly IPedidoRepository _pedidoRepository;

        public ResumoPedidoBusiness(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public ResumoPedidoDto ExibirResumoPedido(int identificadorPedido)
        {
            var pedido = _pedidoRepository.GetById(identificadorPedido);
            if (pedido == null)
                throw new Exception($"O pedido {identificadorPedido} não existe!");

            return new ResumoPedidoDto
            {
                TamanhoPizza = pedido.TamanhoPizza.Tamanho,
                SaborPizza = pedido.SaborPizza.Sabor,
                ValorTamanhoPizza = pedido.TamanhoPizza.Valor,
                TempoPreparo = pedido.Tempo,
                TotalPedido = pedido.Total,
                Personalizacoes = PrencherPersonalizacoes(pedido.AdicionaisPedido)
            };
        }

        private string PrencherPersonalizacoes(IEnumerable<AdicionaisPedido> adicionaisPedido)
        {
            return string.Empty;
        }
    }
}