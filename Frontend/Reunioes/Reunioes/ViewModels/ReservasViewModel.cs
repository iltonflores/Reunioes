﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.ObjectModel;

namespace MvcApplication1
{
    public class ReservasViewModel
    {
        [JsonProperty("GetReservasResult")]
        public Reserva[] reservas { get; set; }
    }
}