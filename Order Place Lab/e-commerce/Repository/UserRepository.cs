using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Web;
using e_commerce.Models;

namespace e_commerce.Repository
{
    public class UserRepository
    {
    
     static Entities db ;

        //constructor nilam ekta 

        static UserRepository()
        {

            db = new Entities();
        }

        //amra Customer Object pass korlam 
        //amra method ta static rakhsi cause amader instance create korte hobe na .amra just call korbo repository . get //
        //thats means eita customer pass kore dibe 
        public static Customer Get(string cId)
        {
            var c = (from cus in db.Customers
                     where cus.Phone == cId
                     select cus).FirstOrDefault();
            

            return c;
        }

        public static Customer Authenticate(string Phone,string Name)
        {
            var c = (from cus in db.Customers
                     where cus.Phone == Phone && 
                     cus.Name == Name
                     select cus).FirstOrDefault();
            //lamda expression is short end LINQ 

            var customer = db.Customers.FirstOrDefault(e => e.Phone == Phone && e.Name == Name);
            return c;



        }
     
    }
}