﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financial.WebAPI
{
    public class ContaPF
    {
        public int? Id { get; set; }
        public int Agencia { get; set; }
        public int Conta { get; set; }
        public string TipoConta { get; set; }
        public string NomeCompleto { get; set; }
    }
}
