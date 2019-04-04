namespace Pizzaria.Application.ViewModels
{
    public class AdicionaisPedidoViewModel
    {
        public int PedidosId { get; set; }

        public virtual PedidoViewModel Pedido { get; set; }

        public int AdicionaisPizzaId { get; set; }

        public virtual AdicionaisPizzaViewModel AdicionalPizza { get; set; }
    }
}