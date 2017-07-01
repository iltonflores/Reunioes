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
            WebClient wc = new WebClient();

            var json = wc.DownloadString("http://localhost:56123/Servicos.svc/getReservas");
            ReservasViewModel reservas = JsonConvert.DeserializeObject<ReservasViewModel>(json);

            return View(reservas);
        }

    }
}
