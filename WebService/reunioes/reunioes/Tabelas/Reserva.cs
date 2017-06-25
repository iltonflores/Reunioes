using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace reunioes
{
    public class Reserva
    {
        public Guid id_reserva { get; set; }
        public Guid id_filial { get; set; }
        public Guid id_sala { get; set; }
        public DateTime dt_inicio { get; set; }
        public DateTime dt_fim { get; set; }
        public Guid id_responsavel { get; set; }
        public Boolean dv_cafe { get; set; }
        public int qt_cafe { get; set; }
        public string nm_descricao { get; set; }
    }
}