using e_commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_commerce.Repository
{
    public class ProductRepository
    {
        static Entities db;
        static ProductRepository()
        {
            db = new Entities();


        }
        //lamda expression ?? 
        //e ta represent korbe Products ar enttites 
        public static Product Get(int id)
        {
            var pr = (from e in db.Products
                      where e.Id == id
                      select e).FirstOrDefault();
            var p = db.Products.FirstOrDefault(e => e.Id == id);

            return p; 
          }
 
        public static List<Product> GetAll()
        {
            var products = db.Products.ToList();
            return products;

        }


    }
}