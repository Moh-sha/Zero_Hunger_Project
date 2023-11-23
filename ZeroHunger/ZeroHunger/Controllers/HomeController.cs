using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ZeroHunger.Models;
using ZeroHunger.Repository;

namespace ZeroHunger.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [HttpPost]
        public ActionResult Login(Employee emp) {

            var employee = NgoRepository.Authenticate(emp.E_Code,emp.E_name);
            if(employee != null)
            {
                FormsAuthentication.SetAuthCookie(employee.E_Code, true);
                return RedirectToAction("Index", "Foodtable");

            }

            return RedirectToAction("Index");

        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}