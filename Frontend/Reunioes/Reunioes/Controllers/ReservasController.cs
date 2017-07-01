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

            var json = wc.DownloadString("http://localhost:56123/Servicos.svc/getReservasTextoLista");
            ReservasTextoListaViewModel reservas = JsonConvert.DeserializeObject<ReservasTextoListaViewModel>(json);

            return View(reservas);
        }

        public ActionResult Cadastra()
        {
            WebClient wc = new WebClient();
            CombosViewModel combos = new CombosViewModel();

            var json = wc.DownloadString("http://localhost:56123/Servicos.svc/getSalas");
            SalasViewModel salas = JsonConvert.DeserializeObject<SalasViewModel>(json);

            json = wc.DownloadString("http://localhost:56123/Servicos.svc/getFiliais");
            FiliaisViewModel filiais = JsonConvert.DeserializeObject<FiliaisViewModel>(json);

            json = wc.DownloadString("http://localhost:56123/Servicos.svc/getResponsaveis");
            ResponsaveisViewModel responsaveis = JsonConvert.DeserializeObject<ResponsaveisViewModel>(json);

            combos.salas = salas.salas;
            combos.filiais = filiais.filiais;
            combos.responsaveis = responsaveis.responsaveis;

            return View(combos);
        }

    }
}
