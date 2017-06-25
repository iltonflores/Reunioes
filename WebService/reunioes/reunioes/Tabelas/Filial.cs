using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace reunioes
{
    public class Filial
    {
        public Guid id_filial { get; set; }
        public string nm_filial { get; set; }
        public Int64 nr_cnpj { get; set; }
        public Guid id_endereco { get; set; }
    }
}