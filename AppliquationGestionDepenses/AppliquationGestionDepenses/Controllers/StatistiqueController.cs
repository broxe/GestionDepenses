using AppliquationGestionDepenses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppliquationGestionDepenses.Controllers
{
    public class StatistiqueController : Controller
    {
        // GET: Statistique
        public ActionResult Index()
        {
            return View();
        }

        //  Obtenir statistique par type
        public ActionResult GetStat ()
        {
            Dictionary<string, int> dictData = new Dictionary<string, int>();

            using (DatabaseDepensesEntities dataDepense = new DatabaseDepensesEntities())
            {
                List<TDepenses> listDepenses = dataDepense.TDepenses.ToList<TDepenses>();                       //  Obtention de tout les données 

                foreach (var it in listDepenses)
                {
                    if (dictData.ContainsKey(it.typeDepense.Trim()))
                    {
                        dictData[it.typeDepense.Trim()] = dictData[it.typeDepense.Trim()] + 1;
                    }
                    else
                    {
                        dictData.Add(it.typeDepense.Trim(), 1);
                    }
                }

                return Json(new { data = dictData }, JsonRequestBehavior.AllowGet);
            }
        }

        //  Obtenir statistique prix par type
        public ActionResult GestStatParPrix()
        {
            Dictionary<string, double> dictData = new Dictionary<string, double>();

            using (DatabaseDepensesEntities dataDepense = new DatabaseDepensesEntities())
            {
                List<TDepenses> listDepenses = dataDepense.TDepenses.ToList<TDepenses>();                       //  Obtention de tout les données 

                foreach (var it in listDepenses)
                {
                    if (dictData.ContainsKey(it.typeDepense.Trim()))
                    {
                        dictData[it.typeDepense.Trim()] = dictData[it.typeDepense.Trim()] + it.prixDepense;
                    }
                    else
                    {
                        dictData.Add(it.typeDepense.Trim(), it.prixDepense);
                    }
                }

                return Json(new { data = dictData }, JsonRequestBehavior.AllowGet);
            }
        }

        //  Sta

    }
}