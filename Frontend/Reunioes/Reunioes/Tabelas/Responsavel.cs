using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Tabelas
{
    public class Responsavel
    {
        public Guid id_responsavel { get; set; }
        public string nm_responsavel { get; set; }
        public Int64 nr_cpf { get; set; }
        public Int64 nr_telefone { get; set; }
    }
}