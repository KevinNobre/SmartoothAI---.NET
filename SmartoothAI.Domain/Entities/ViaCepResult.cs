﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartoothAI.Domain.Entities
{
    public class ViaCepResult
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; } 
        public string Uf { get; set; }
        public bool Erro { get; set; } 
    }
}
