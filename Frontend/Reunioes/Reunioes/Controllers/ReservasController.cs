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
        Guid id_reserva_altera;

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

        public String PostReserva(String descricao, String qt_cafe, Boolean dv_cafe, Guid id_filial, Guid id_sala, Guid id_responsavel, DateTime dt_inicio, DateTime dt_fim)
        {
            Reserva reserva = new Reserva();

            Int16 qt_cafe_int;

            if (qt_cafe.Equals("") || !dv_cafe)
            {
                qt_cafe_int = 0;
            }
            else
            {
                qt_cafe_int = Convert.ToInt16(qt_cafe);
            }

            reserva.nm_descricao = descricao;
            reserva.qt_cafe = qt_cafe_int;
            reserva.dv_cafe = dv_cafe;
            reserva.id_filial = id_filial;
            reserva.id_sala = id_sala;
            reserva.id_responsavel = id_responsavel;
            reserva.dt_inicio = dt_inicio;
            reserva.dt_fim = dt_fim;

            String json = JsonConvert.SerializeObject(reserva);

            Utils utils = new Utils();

            String retornostr = utils.PostWebService("http://localhost:56123/Servicos.svc/postReserva", json);

            Retorno retorno = JsonConvert.DeserializeObject<Retorno>(retornostr);

            return retorno.DescricaoRetorno;
        }

        public ActionResult AlteraReserva(String id_reserva)
        {
            if (!String.IsNullOrEmpty(id_reserva))
            {
                id_reserva_altera = new Guid(id_reserva);
            }

            WebClient wc = new WebClient();

            EditaReservaCombosViewModel combos = new EditaReservaCombosViewModel();

            var json = wc.DownloadString("http://localhost:56123/Servicos.svc/getSalas");
            SalasViewModel salas = JsonConvert.DeserializeObject<SalasViewModel>(json);

            json = wc.DownloadString("http://localhost:56123/Servicos.svc/getFiliais");
            FiliaisViewModel filiais = JsonConvert.DeserializeObject<FiliaisViewModel>(json);

            json = wc.DownloadString("http://localhost:56123/Servicos.svc/getResponsaveis");
            ResponsaveisViewModel responsaveis = JsonConvert.DeserializeObject<ResponsaveisViewModel>(json);

            json = wc.DownloadString("http://localhost:56123/Servicos.svc/getReservas");
            ReservasViewModel reservas = JsonConvert.DeserializeObject<ReservasViewModel>(json);

            combos.salas = salas.salas;
            combos.filiais = filiais.filiais;
            combos.responsaveis = responsaveis.responsaveis;
            combos.reservas = reservas.reservas;

            return View(combos);
        }

    }
}
