using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroupA.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Nosotros";
            ViewBag.Mision = "Nuestra misión es ofrecer servicios de análisis, diseño, desarrollo y mantenim" +
                "iento de soluciones sistémicas de tecnología, puntualmente en sistemas que implementen base de datos locales y externos, que aporten v" +
                "alor añadido a nuestros clientes y ayuden a mejorar sus procesos de negocio. Nuestro enfoque se basa en situar al cliente en el centro de nues" +
                "tra actividad, poniendo todo nuestro conocimiento a su servicio de forma que éste pueda confiarnos su sistema informático, y así, enfocarse plenamente e" +
                "n su negocio. Para ello, ofrecemos un servicio de calidad y establecemos relaciones de colaboración a largo plazo que generen satisfacción y rentabilidad en nu" +
                "estros clientes, empleados y socios de negocio.Garantizamos y optimizamos la seguridad, integridad y estabilidad de las bases de datos, que administran la informació" +
                "n de las operaciones del negocio, para tener su disponibilidad absoluta, según las necesidades de las diferentes áreas de la compañía.";
            ViewBag.Vision = "Nuestra empresa aspira a convertirse en un proveedor de servicios de administración de base de datos pionera y reconocida a nivel regional, una empresa sólida" +
                " y en constante crecimiento, comprometida con la protección y seguridad tecnológica, facilitando el acceso a los datos para luego simplificar la dificultad de toma de decisiones.";
            ViewBag.NombreEmpresa = "Group A";
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.LoremIpsum = @"Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
                                Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. 
                                Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. 
                                Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            ViewBag.Message = "Nosotros";
            ViewBag.Mision = "Ser una empresa encargada del desarrollo de sistemas Web para empresas ofreciendo un servicio de alta calidad,tecnología confiable y diseños de vanguardia. Maximizando el potencial de nuestros clientes a través del internet.";
            ViewBag.Vision = "Ser la empresa de desarrolladores de Páginas Web más elegida y cotizada por su compromiso, originalidad  y capacidad de potenciar a nuestros clientes en el mercado digital.";
            var lista = new List<String>();
            lista.Add("Poder captar la idea del cliente, darle estética y funcionalidad.");
            lista.Add("Calidad adaptable a todos los navegadores, dándole prioridad a la usabilidad.");
            lista.Add("Que los proyectos de nuestros clientes alcancen una mayor visibilidad a nivel global");
            ViewBag.Objetivos = lista;
           
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}