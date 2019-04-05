using System.Collections.Generic;

namespace Pizzaria.Domain.Models
{
    public class Pedidos
    {
        public int Id { get; set; }

        public int SaboresPizzaId { get; set; }

        public virtual SaboresPizza SaborPizza { get; set; }

        public int TamanhoPizzaId { get; set; }

        public virtual TamanhosPizza TamanhoPizza { get; set; }

        public decimal Total { get; set; }

        public int Tempo { get; set; }

        public bool? Finalizado { get; set; }

        public virtual IEnumerable<AdicionaisPedido> AdicionaisPedido { get; set; }
    }
} 