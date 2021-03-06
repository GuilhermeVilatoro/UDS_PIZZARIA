﻿using System.Collections.Generic;

namespace Pizzaria.Domain.Models
{
    public class AdicionaisPizza
    {
        public int Id { get; set; }

        public string Adicional { get; set; }

        public decimal? Valor { get; set; }

        public int? Tempo { get; set; }

        public IList<AdicionaisPedido> AdicionaisPedido { get; set; }
    }
}