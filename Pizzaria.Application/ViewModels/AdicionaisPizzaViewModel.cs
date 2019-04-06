using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Pizzaria.Application.ViewModels
{
    public class AdicionaisPizzaViewModel
    {
        [Key]
        public int Id { get; set; }

        [Description("Adicional da Pizza")]
        [Required(ErrorMessage = "Preencha o campo Adicional")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        public string Adicional { get; set; }

        [Description("Tempo adicional atribuído a alguns adicionais da pizza")]
        public decimal? Valor { get; set; }

        [Description("Tempo adicional atribuído a alguns adicionais da pizza")]
        public int? Tempo { get; set; }        
    }
}