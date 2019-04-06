using Pizzaria.Domain.Models;
using System.Collections.Generic;

namespace Pizzaria.Domain.Business.Dto
{
    public class ResumoPedidoDto
    {
        public string SaborPizza { get; set; }

        public string TamanhoPizza { get; set; }

        public IList<AdicionaisPizza> Personalizacoes { get; set; }
     
        public decimal Total { get; set; }
        
        public int Tempo { get; set; }

        public bool? Finalizado { get; set; }
    }
}