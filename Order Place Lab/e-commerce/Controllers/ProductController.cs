using e_commerce.Models;
using e_commerce.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace e_commerce.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var products = ProductRepository.GetAll();
            return View(products);
        }


        public ActionResult AddtoCart(int id)
        {
            var p = ProductRepository.Get(id);
            //cart a add korar jnno sessionkey Use korsilam 

            List<Product> products;
            //session tekhe check korbo 

            if (Session["cart"] == null)
            {

                products = new List<Product>();


            }
            //session tekhe cart ta nibo
            else
            {

                var json = Session["cart"].ToString();
                products = new JavaScriptSerializer().Deserialize<List<Product>>(json);
            }
            p.Qty = 1;
            products.Add(p);
            var json2 = new  JavaScriptSerializer().Serialize(products);
            Session["cart"]=json2;

            return RedirectToAction("Index");
        
        }

        public ActionResult Cart()
        {

            var json = Session["cart"].ToString();
           var products = new JavaScriptSerializer().Deserialize<List<Product>>(json);

            return View(products);


        }

        public ActionResult Checkout()
        {

            var json = Session["cart"].ToString();
            var products = new JavaScriptSerializer().Deserialize<List<Product>>(json);
            OrderRepository.PlaceOrder(products,User.Identity.Name);
            return RedirectToAction("Index");

        }

    }
}