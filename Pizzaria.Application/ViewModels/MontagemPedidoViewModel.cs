using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Pizzaria.Application.ViewModels
{
    public class MontagemPedidoViewModel
    {        
        [Description("Tamanho da Pizza")]
        [Required(ErrorMessage = "Preencha o campo Tamanho")]
        [MaxLength(50, ErrorMessage = "Máximo {0} caracteres")]
        public string TamanhoPizza { get; set; }

        [Description("Sabor da Pizza")]
        [Required(ErrorMessage = "Preencha o campo Sabor")]
        [MaxLength(200, ErrorMessage = "Máximo {0} caracteres")]
        public string SaborPizza { get; set; }      
    }   
}