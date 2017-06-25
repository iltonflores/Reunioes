using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace reunioes
{
    public class Endereco
    {
        public Guid id_endereco { get; set; }
        public string nm_rua { get; set; }
        public int nr_rua { get; set; }
        public string nm_bairro { get; set; }
        public string nm_cidade { get; set; }
        public string nm_estado { get; set; }
        public int nr_cep { get; set; }
    }
}