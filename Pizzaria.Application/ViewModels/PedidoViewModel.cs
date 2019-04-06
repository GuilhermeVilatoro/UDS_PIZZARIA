using Pizzaria.Domain.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Pizzaria.Application.ViewModels
{
    public class PedidoViewModel
    {
        [Key]
        public int Id { get; set; }

        public int SaboresPizzaId { get; set; }

        public int TamanhoPizzaId { get; set; }

        public virtual SaboresPizzaViewModel SaborPizza { get; set; }

        public virtual TamanhosPizzaViewModel TamanhoPizza { get; set; }

        [Description("Custo total do pedido")]
        [Required(ErrorMessage = "Preencha o campo Total")]
        public decimal Total { get; set; }

        [Description("Tempo total do pedido")]
        [Required(ErrorMessage = "Preencha o campo Tempo")]
        public int Tempo { get; set; }

        public bool? Finalizado { get; set; }

        public virtual IList<AdicionaisPedido> AdicionaisPedido { get; set; }
    }
}