using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProvaTLP.Models;




namespace ProvaTLP.Models
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cervejas()
        {
            ViewBag.Title = "Cervejas artesanais";
            ViewBag.Message = "Menu de Cervejas";


            var lista = Cerveja.GetCerveja();
            ViewBag.Lista = lista;


            return View();
        }

        public ActionResult Contact()
        {

            ViewBag.Title = "Informações para Contato";
            ViewBag.Message = "Cervejaria artesanal Vikings ® ";

            return View();
        }
    }
}