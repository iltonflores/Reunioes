﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1
{
    public class ReservaTextoLista
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
        public string nm_sala { get; set; }
        public string nm_filial { get; set; }
        public string nm_responsavel { get; set; }
    }
}