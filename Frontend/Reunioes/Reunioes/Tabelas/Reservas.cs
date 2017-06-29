using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1
{
    public class Reservas
    {
        [JsonProperty("GetReservasResult")]
        public Reserva[] reservas { get; set; }
    }
}