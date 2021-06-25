using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Colaciones.Controllers
{
    public class ProductoController : Controller
    {
        public IActionResult Index(
            int categoria_id = -1,
            int colacion = 0, 
            int desayuno = 0, 
            int postre = 0,
            int grasas_trans = 0,
            int ocasional = 0,
            int reemplazo = 0,
            string txtBusqueda = "")
        {

            ViewBag.ListOfCategorias = Datos.ObtenerCategorias();

            return View(Datos.ObtenerProductos(txtBusqueda,categoria_id,colacion,desayuno,0,postre,0,grasas_trans,ocasional,reemplazo));
        }

        [HttpPost]
        public IActionResult Filtro(
              int  categoria_id,
              bool chkcolacion , 
              bool chkdesayuno, 
              bool chkpostre,
              bool chkgrasas_trans,
              bool chkocasional,
              bool chkreemplazo,
              string txtBusqueda)
        {

            /* HttpContext.Session.SetInt32("PAG_TORNEO", 1);*/

            HttpContext.Session.SetInt32("CATEGORIA_ID", (categoria_id == 0 ? -1 : categoria_id));
            HttpContext.Session.SetInt32("COLACION", (chkcolacion ? 1 : -1));
            HttpContext.Session.SetInt32("DESAYUNO", (chkdesayuno ? 1 : -1));
            HttpContext.Session.SetInt32("POSTRE", (chkpostre ? 1 : -1));
            HttpContext.Session.SetInt32("GRASAS_TRANS", (chkgrasas_trans ? 1 : -1));
            HttpContext.Session.SetInt32("OCASIONAL", (chkocasional ? 1 : -1));
            HttpContext.Session.SetInt32("REEMPLAZO", (chkreemplazo ? 1 : -1));


            return RedirectToAction("Index", new {
                                               categoria_id = (categoria_id==0 ? -1: categoria_id),
                                               colacion = (chkcolacion ? 1 : 0), 
                                               desayuno = (chkdesayuno ? 1 : 0), 
                                               postre = (chkpostre ? 1 : 0),
                                               grasas_trans = (chkgrasas_trans ? 1 : 0),
                                               ocasional = (chkocasional ? 1 : 0),
                                               reemplazo = (chkreemplazo ? 1 : 0),
                                               txtBusqueda = txtBusqueda });

        }

    }
}