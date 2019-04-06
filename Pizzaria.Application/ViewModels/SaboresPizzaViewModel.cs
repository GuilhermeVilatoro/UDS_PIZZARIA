using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Pizzaria.Application.ViewModels
{
    public class SaboresPizzaViewModel
    {
        [Key]
        public int Id { get; set; }

        [Description("Sabor da Pizza")]
        [Required(ErrorMessage = "Preencha o campo Sabor")]
        [MaxLength(200, ErrorMessage = "Máximo {0} caracteres")]
        public string Sabor { get; set; }

        [Description("Tempo adicional atribuído a alguns sabores")]
        public int? TempoAdicional { get; set; }        
    }
}