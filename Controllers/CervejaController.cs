using ProvaLibrary.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProvaTLP.Controllers
{
    public class CervejaController : Controller
    {
        // GET: Cerveja
        public ActionResult Index()
        {
            var cervejas = new CervejasRepositorio();

            ViewBag.Cervejas = cervejas.BuscarTodas();

            return View();
        }

        public ActionResult Detalhes(int id)
        {
            var cervejas = new CervejasRepositorio();

            ViewBag.Cerveja = cervejas.BuscarPorId(id);

            return View(cervejas.BuscarPorId(id));
        }
    }
}