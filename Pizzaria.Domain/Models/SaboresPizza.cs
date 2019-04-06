using System.Collections.Generic;

namespace Pizzaria.Domain.Models
{
    public class SaboresPizza
    {
        public int Id { get; set; }

        public string Sabor { get; set; }

        public int? TempoAdicional { get; set; }

        public IList<Pedidos> Pedidos { get; set; }
    }
}