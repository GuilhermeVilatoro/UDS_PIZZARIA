namespace Pizzaria.Domain.Business.Dto
{
    public class ResumoPedidoDto
    {
        public string TamanhoPizza { get; set; }

        public decimal ValorTamanhoPizza { get; set; }

        public string SaborPizza { get; set; }     

        public string Personalizacoes { get; set; }

        public decimal TotalPedido { get; set; }

        public int TempoPreparo { get; set; }
    }
}