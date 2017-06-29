using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class ReservasController : Controller
    {
        //
        // GET: /Reservas/

        public ActionResult Listagem()
        {
            Reservas reservas=carregaLista();
            return View();
        }

        public Reservas carregaLista()
        {

            WebClient wc = new WebClient();

            var json = wc.DownloadString("http://localhost:56123/Servicos.svc/getReservas");
            Reservas reservas = JsonConvert.DeserializeObject<Reservas>(json);

            return reservas;
        }

    }
}
