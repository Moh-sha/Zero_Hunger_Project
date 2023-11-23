using e_commerce.Models;
using e_commerce.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace e_commerce.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Customer c) {

            var user = UserRepository.Authenticate(c.Phone, c.Name);
            if(user != null)
            {
                //true -   authentication cookie should be persistent
                //false -  authentication cookie should be non-persistent
                FormsAuthentication.SetAuthCookie(user.Phone, true);
                return RedirectToAction("Index", "Product");
            }
 
         return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}