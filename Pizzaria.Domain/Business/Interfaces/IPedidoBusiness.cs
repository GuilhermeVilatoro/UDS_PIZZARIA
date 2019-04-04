using Pizzaria.Domain.Business.Dto;
using Pizzaria.Domain.Business.Enums;

namespace Pizzaria.Domain.Business.Interfaces
{
    public interface IPedidoBusiness
    {
        void IniciarPedido(DadosIniciaisPedidoDto dadosIniciaisPedido);

        void PersonalizarPedido(AdicionalPizzaEnum adicionalPizza);

        PedidoDto ExibirPedido(long idPedido);
    }
}