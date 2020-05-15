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

        public ActionResult GetData()
        {
            using (DatabaseDepensesEntities dataDepense = new DatabaseDepensesEntities())
            {
                List<TDepenses> listDepenses = dataDepense.TDepenses.ToList<TDepenses>();
                return Json(new { data = listDepenses }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult AddOrEdit(int id =0)
        {
            return View(new TDepenses());
        }

        [HttpPost]
        public ActionResult AddOrEdit(TDepenses depense)
        {
            using (DatabaseDepensesEntities dataDepense = new DatabaseDepensesEntities())
            {
                dataDepense.TDepenses.Add(depense);
                dataDepense.SaveChanges();
                return Json(new { succes = true, message = "Saved Succefully" });
            }
        }


    }
}