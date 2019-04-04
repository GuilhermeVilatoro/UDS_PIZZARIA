using Pizzaria.Domain.Business.Enums;

namespace Pizzaria.Domain.Business.Dto
{
    public class DadosIniciaisPedidoDto
    {
        public TamanhosPizzaEnum TamanhosPizza { get; set; }
        public SaboresPizzaEnum SaboresPizza { get; set; }
    }
}