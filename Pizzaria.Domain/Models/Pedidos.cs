using System.Collections.Generic;

namespace Pizzaria.Domain.Models
{
    public class Pedidos
    {
        public int Id { get; set; }

        public int SaboresPizzaId { get; set; }

        public SaboresPizza SaboresPizza { get; set; }

        public int TamanhosPizzaId { get; set; }

        public TamanhosPizza TamanhosPizza { get; set; }

        public decimal Total { get; set; }

        public int Tempo { get; set; }

        public bool? Finalizado { get; set; }

        public IList<AdicionaisPedido> AdicionaisPedido { get; set; }
    }
} 