using AplicacionBlanco.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AplicacionBlanco.Controllers
{
    public class AEROPUERTO_APIController : Controller
    {
        // GET: AEROPUERTO_API
        public JsonResult Get()
        {
            
            //var subtemas = db.SUBTEMAS.Where(x => x.TEMA_id == id);
            var salida = new AEROPUERTOS();
            //return Json(salida.Aeropuertos, JsonRequestBehavior.AllowGet);
            //return Json(salida.Aeropuertos.GetRange(1, 5000), JsonRequestBehavior.AllowGet);
            return Json(salida.Aeropuertos[1], JsonRequestBehavior.AllowGet);
        }

        public JsonResult Buscador(string id)
        {
            id = id.ToUpper();
            var salida = new AEROPUERTOS();
            if (id.Length <= 2)
            {
                return Json(new List<AEROPUERTO>(), JsonRequestBehavior.AllowGet);
            }
            if (id.Length > 2 && id.Length < 5)
            {
                return Json(salida.Aeropuertos.Where(m => m.IATA.Contains(id) || m.ICAO.Contains(id)), JsonRequestBehavior.AllowGet);
            }            
            return Json(salida.Aeropuertos.Where(m => m.NOMBRE.ToUpper().Contains(id)), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Test(int id,int id2)
        {
            var salida = new AEROPUERTOS();
            AEROPUERTO p1 = salida.Aeropuertos.Where(m => m.AIRPORT_ID == id).First();
            AEROPUERTO p2 = salida.Aeropuertos.Where(m => m.AIRPORT_ID == id2).First();
            /*
            p1.LATITUD = 1;
            p2.LATITUD = 0;
            p1.LONGITUD = 0;
            p2.LONGITUD = 0;
            */
            //int salida = 1;
            return Json(CALCULOS.ValorFinal(p1,p2), JsonRequestBehavior.AllowGet);
        }
        /*
        public string Get(string id)
        {
            //var subtemas = db.SUBTEMAS.Where(x => x.TEMA_id == id);
            var salida = new AEROPUERTOS();
            //return Json(salida.Aeropuertos, JsonRequestBehavior.AllowGet);
            //return Json(salida.Aeropuertos.Where(m => m.NOMBRE.Contains(id)), JsonRequestBehavior.AllowGet);
            //return Json(salida.Aeropuertos[1], JsonRequestBehavior.AllowGet);
            return "Hola";

        }
        */
    }
}