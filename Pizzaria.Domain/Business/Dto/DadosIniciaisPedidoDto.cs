using Pizzaria.Domain.Business.Enums;
using Pizzaria.Domain.Models;

namespace Pizzaria.Domain.Business.Dto
{
    public class DadosIniciaisPedidoDto
    {
        public TamanhosPizza TamanhoPizza { get; set; }
        public SaboresPizza SaborePizza { get; set; }
    }
}