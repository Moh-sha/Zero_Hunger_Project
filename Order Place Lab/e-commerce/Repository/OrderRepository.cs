using e_commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace e_commerce.Repository
{
    public class OrderRepository
    {

        static Entities db;

        static OrderRepository()
        {



            db = new Entities();


        }

        public static void PlaceOrder(List<Product> products , String U_id)
        {


            Order O = new Order();
            O.Amount = 10000;
            O.Status = "Ordered";
            O.CustomerPhone = U_id;
            db.Orders.Add(O);
            db.SaveChanges();
             
            // Order Details ar jnno 


            foreach (var P in products)
            {

                var Odr = new OrderDetail()
                {
                    OrderId = O.Id,
                    ProductId = P.Id,
                    UnitPrice = P.Price,
                    Qty = P.Qty,




                };
                db.OrderDetails.Add(Odr);
                db.SaveChanges();







            }








        } 

    }

}