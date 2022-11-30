using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProvaTLP
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
              routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(

               "CervejaSalvar",
               "Cerveja/Salvar",
               new { controller = "Cerveja", action = "Salvar" }
               );



            routes.MapRoute(

               "CervejaExcluir",
               "Cerveja/Excluir/:id",
               new { controller = "Cerveja", action = "Excluir", id = 0 }
               );

            routes.MapRoute(

               "CervejaAlterar",
               "Cerveja/Alterar/:id",
               new { controller = "Cerveja", action = "Alterar",id=0 }
               );



            routes.MapRoute(

                "CervejaAdicionar",
                "Cerveja/Adicionar",
                new { controller ="Cerveja", action= "Adicionar"}
                );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
