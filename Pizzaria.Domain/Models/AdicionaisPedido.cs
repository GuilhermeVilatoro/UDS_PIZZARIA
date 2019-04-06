namespace Pizzaria.Domain.Models
{
    public class AdicionaisPedido
    {
        public int PedidosId { get; set; }

        public Pedidos Pedidos { get; set; }

        public int AdicionaisPizzaId { get; set; }

        public AdicionaisPizza AdicionaisPizza { get; set; }
    }
}