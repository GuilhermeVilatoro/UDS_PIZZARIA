using System.Collections.Generic;

namespace Pizzaria.Domain.Models
{
    public class TamanhosPizza
    {
        public int Id { get; set; }

        public string Tamanho { get; set; }

        public decimal Valor { get; set; }

        public int Tempo { get; set; }

        public IList<Pedidos> Pedidos { get; set; }
    }
}