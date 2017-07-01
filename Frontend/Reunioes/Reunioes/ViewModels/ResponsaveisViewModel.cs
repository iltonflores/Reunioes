using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.ObjectModel;
using MvcApplication1;

namespace MvcApplication1
{
    public class ResponsaveisViewModel
    {
        [JsonProperty("GetResponsaveisResult")]
        public Responsavel[] responsavel { get; set; }
    }
}