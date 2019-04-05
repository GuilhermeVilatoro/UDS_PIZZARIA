namespace Pizzaria.Domain.Models
{
    public class AdicionaisPedido
    {
        public int PedidosId { get; set; }

        public virtual Pedidos Pedido { get; set; }

        public int AdicionaisPizzaId { get; set; }

        public virtual AdicionaisPizza AdicionalPizza { get; set; }
    }
}