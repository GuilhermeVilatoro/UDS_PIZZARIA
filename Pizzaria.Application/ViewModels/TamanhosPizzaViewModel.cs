using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Pizzaria.Application.ViewModels
{
    public class TamanhosPizzaViewModel
    {
        [Key]
        public int Id { get; set; }

        [Description("Tamanho da Pizza")]
        [Required(ErrorMessage = "Preencha o campo Tamanho")]
        [MaxLength(50, ErrorMessage = "Máximo {0} caracteres")]
        public string Tamanho { get; set; }

        [Description("Custo atribuído a cada tamanho de pizza")]
        [Required(ErrorMessage = "Preencha o campo Valor")]
        public decimal Valor { get; set; }

        [Description("Tempo atribuído a cada tamanho de pizza")]
        [Required(ErrorMessage = "Preencha o campo Tempo")]
        public int Tempo { get; set; }
    }
}