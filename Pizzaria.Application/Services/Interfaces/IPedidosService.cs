using Pizzaria.Application.ViewModels;

namespace Pizzaria.Application.Services
{
    public interface IPedidosService
    {
        PedidoViewModel MontarPedido(MontagemPedidoViewModel montagemPedido);

        PedidoViewModel PersonalizarPedido(PersonalizacaoPedidoViewModel personalizacaoPedido);

        ResumoPedidoViewModel ExibirResumoPedido(int identificadorPedido);

        void FinalizarPedido(int identificadorPedido);
    }
}