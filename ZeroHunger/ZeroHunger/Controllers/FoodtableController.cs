using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using ZeroHunger.Models;
using ZeroHunger.Repository;

namespace ZeroHunger.Controllers
{
    /// <summary>
     [Authorize]
    /// </summary>
    public class FoodtableController : Controller
    {
        // GET: Foodtable
        public ActionResult Index()
        {

            var foodtables = FoodRepository.GetAll();


            return View(foodtables);
        }

        public ActionResult Indexx()
        {

             var Dashboards = EmployeeRepository.GetAll();


            return View(Dashboards);
        }


        public ActionResult CollectRequest(int id)
        {
            var p = FoodRepository.Get(id);
            List<Foodtable> foodtables;

            if (Session["cart"] == null)
            {
                foodtables = new List<Foodtable>();
            }
            else
            {
                var json = Session["cart"].ToString();
                foodtables = JsonConvert.DeserializeObject<List<Foodtable>>(json);
            }

            p.Food_Qty = 1;
            foodtables.Add(p);

            var json2 = JsonConvert.SerializeObject(foodtables, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                // Add other settings as needed
            });

            Session["cart"] = json2;
            return RedirectToAction("Index");
        }

        public ActionResult Request()
        {
            if (Session["cart"] == null)
            {
                var emptyFoodtables = new List<Foodtable>();
                return View(emptyFoodtables);
            }

            var json = Session["cart"].ToString();
            var foodtables = JsonConvert.DeserializeObject<List<Foodtable>>(json);

            return View(foodtables);
        }


        public ActionResult OrderCheckout()
        {
            if (Session["cart"] == null)
            {
                // Handle the case when the cart is empty
                // You might want to return a specific view or message
                return RedirectToAction("Index");
            }

            var json = Session["cart"].ToString();
            var foodtables = JsonConvert.DeserializeObject<List<Foodtable>>(json);

            OrderRepository.PlaceOrder(foodtables, User.Identity.Name);
            return RedirectToAction("Indexx");
        }

    }
}