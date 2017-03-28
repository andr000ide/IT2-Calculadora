using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CalculadoraMelhorada.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //inicializar valores
            ViewBag.Visor = "0";
            Session["PrimeiroOperador"] = true;
            return View();
        }

        //POST : Home
        [HttpPost]
        public ActionResult Index(string bt, string visor)
        {
            switch (bt)
            {
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    //determinar se no VISOR só existe um zero
                    if (visor.Equals("0")) visor = bt;
                    else visor += bt; // visor = visor+bt;
                    break;
                case ",":
                    if (!visor.Contains(",")) { visor += ","; }
                    break;
                case "+/-":
                    //visor = Convert.ToDouble(visor) * -1 + "";
                    if (visor.StartsWith("-")) { visor.Replace("-", ""); }
                    else if( !visor.Equals("0") )visor = "-" + visor;
                    break;
                case "c":
                    visor = "0";
                    Session["PrimeiroOperador"] = true;
                    break;
                case "+":
                case "-":
                case "x":
                case ":":
                    if ((bool)Session["PrimeiroOperador"])
                    {
                        //guardar valor do VISOR
                        Session["operando"] = visor;
                        //limpar o VISOR
                        visor = "0";
                        //guardar o OPERADOR 
                        Session["operador"] = bt;
                        //marcar como tendo utilizado o operador
                        Session["PrimeiroOperador"] = false;
                    }
                    else
                    {
                        // se não é a primeira vez que se clica num OPERADOR 
                        // vou utilizar os valores anteriores
                        switch ((string)Session["operador"])
                        {
                            //recuperar código da primeira calculadora
                        }
                        //guardar os novos valores ... 
                    }
                    break;
            }
            //entregar os valores à VIEW 
            ViewBag.Visor = visor;
            return View();
        }
    }
}