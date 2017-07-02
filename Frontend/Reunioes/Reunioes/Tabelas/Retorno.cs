using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1
{
    public class Retorno
    {
        [JsonProperty("CodigoRetorno")]
        public int CodigoRetorno { get; set; }
        [JsonProperty("DescricaoRetorno")]
        public String DescricaoRetorno { get; set; }
        [JsonProperty("guid")]
        public Guid guid { get; set; }
    }
}