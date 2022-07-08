using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DesafioCrud
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuração e serviços de API Web

            // Rotas de API Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "ProdutoApi",
                routeTemplate: "api/v1/{controller}/{id}",
                defaults: new { controller = "Products", id = RouteParameter.Optional }
            );
        }
    }
}
