using ProvaTLP.Models;
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
        public ActionResult Adicionar()
        {

            ViewBag.Title = "Cervejas";
            ViewBag.Message = "Adicionar Cervejas";

            return View();
        }

        
        [HttpPost]

        public void Salvar()
        {


            var cerveja = new Cerveja();
            cerveja.Id =Convert.ToInt32("0" + Request["id"]);
            cerveja.Nome = Request["nome"];
            cerveja.Tipo = Request["tipo"];
            cerveja.Ano = Convert.ToInt16(Request["ano"]);
            cerveja.Fabricacao = Convert.ToInt16(Request["fabricacao"]);
            cerveja.Cor = Request["cor"];
            cerveja.Embalagem = Convert.ToByte(Request["embalegem"]);
            cerveja.Alcoolica = true;
          
            cerveja.Valor = Convert.ToDecimal(Request["valor"]);
            cerveja.Ativo = true;

            cerveja.Salvar();

            Response.Redirect("/Home/Cervejas");

        }


        public ActionResult Alterar(int id)
        {

            ViewBag.Title = "Cerveja";
            ViewBag.Message = "Alterar Cerveja"  + id;

            var cervejas = new Cerveja();
            cervejas.GetCervejas(id);
            ViewBag.Cervejas = cervejas;

            return View();
        }

        public ActionResult Excluir(int id)
        {

            ViewBag.Title = "Cerveja";
            ViewBag.Message = "Excluir Cerveja" + id;

            var cervejas = new Cerveja();
            cervejas.GetCervejas(id);
             ViewBag.Cervejas = cervejas;

            return View();
        }

        [HttpPost]
        public void Excluir()
        {
            var cervejas = new Cerveja();
            cervejas.Id = Convert.ToInt32("0" + Request["id"]);
            cervejas.Excluir();
            Response.Redirect("/Home/Cervejas");


        }

    }
}