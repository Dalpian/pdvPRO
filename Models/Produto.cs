﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pdvPRO.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Categoria Categoria { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public float PrecoCusto { get; set; }
        public float PrecoVenda { get; set; }
        public int UnidadeMedida { get; set; }
        public bool Status { get; set; }
    }
}
