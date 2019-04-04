using Pizzaria.Domain.Business.Dto;
using Pizzaria.Domain.Business.Enums;
using Pizzaria.Domain.Business.Interfaces;

namespace Pizzaria.Domain.Business
{
    public class PedidoBusiness : IPedidoBusiness
    {        
        public void IniciarPedido(DadosIniciaisPedidoDto dadosIniciaisPedido)
        {
            throw new System.NotImplementedException();
        }

        public void PersonalizarPedido(AdicionalPizzaEnum adicionalPizza)
        {
            throw new System.NotImplementedException();
        }

        public PedidoDto ExibirPedido(long idPedido)
        {
            throw new System.NotImplementedException();
        }
    }
}