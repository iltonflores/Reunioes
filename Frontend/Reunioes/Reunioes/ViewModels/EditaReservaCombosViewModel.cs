﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.ObjectModel;

namespace MvcApplication1
{
    public class EditaReservaCombosViewModel
    {
        public Filial[] filiais { get; set; }
        public Sala[] salas { get; set; }
        public Responsavel[] responsaveis { get; set; }
        public Reserva[] reservas { get; set; }
    }
}