using Pizzaria.Application.ViewModels;

namespace Pizzaria.Application.Services
{
    public interface IPedidosService
    {
        PedidoViewModel MontarPedido(MontagemPedidoViewModel montagemPedido);

        PedidoViewModel PersonalizarPedido(PersonalizacaoPedidoViewModel personalizacaoPedido);

        PedidoViewModel ExibirPedido(int identificadorPedido);

        void FinalizarPedido(int identificadorPedido);
    }
}