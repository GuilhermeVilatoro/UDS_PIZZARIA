using System.Collections.Generic;

namespace Pizzaria.Application.ViewModels
{
    public class PedidoViewModel
    {
        public string SaborPizza { get; set; }

        public string TamanhoPizza { get; set; }

        public IList<AdicionaisPizzaViewModel> Personalizacoes { get; set; }

        public decimal Total { get; set; }

        public int Tempo { get; set; }

        public bool? Finalizado { get; set; }
    }
}