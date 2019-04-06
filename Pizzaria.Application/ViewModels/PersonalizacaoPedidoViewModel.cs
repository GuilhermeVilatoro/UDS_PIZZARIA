using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Pizzaria.Application.ViewModels
{
    public class PersonalizacaoPedidoViewModel
    {
        [Description("Identificador do pedido")]
        [Required(ErrorMessage = "Preencha o campo Identificador do pedido a ser personalizado")]
        public int IdentificadorPedido { get; set; }

        [Description("Adicional da Pizza")]
        [Required(ErrorMessage = "Preencha o campo Adicional")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        public string AdicionalPizza { get; set; }
    }
}