using AppliquationGestionDepenses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppliquationGestionDepenses.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult GetData()
        {
            using (DatabaseDepensesEntities dataDepense = new DatabaseDepensesEntities())
            {
                List<TDepenses> listDepenses = dataDepense.TDepenses.ToList<TDepenses>();
                return Json(new { data = listDepenses }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id =0)
        {
            if (id == 0)
                return View(new TDepenses());
            else
            {
                using (DatabaseDepensesEntities dataDepense = new DatabaseDepensesEntities())
                {
                    return View(dataDepense.TDepenses.Where(x => x.IdDepense == id).FirstOrDefault<TDepenses>());
                }
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(TDepenses depense)
        {
            using (DatabaseDepensesEntities dataDepense = new DatabaseDepensesEntities())
            {
                depense.IdDepense = dataDepense.TDepenses.Max(x => x.IdDepense) +1;
                dataDepense.TDepenses.Add(depense);
                dataDepense.SaveChanges();
                return Json(new { succes = true, message = "Saved Succefully" });
            }
        }


        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (DatabaseDepensesEntities dataDepense = new DatabaseDepensesEntities())
            {
                TDepenses tmps = dataDepense.TDepenses.Where(x => x.IdDepense == id).FirstOrDefault<TDepenses>();
                dataDepense.TDepenses.Remove(tmps);
                dataDepense.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }


    }
}