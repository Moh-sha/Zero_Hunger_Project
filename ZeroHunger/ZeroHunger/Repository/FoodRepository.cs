using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using ZeroHunger.Models;

namespace ZeroHunger.Repository
{
    public class FoodRepository
    {
        static ZeroHungerEntities db;

        static FoodRepository()
        {


            db = new ZeroHungerEntities();
        }

        public static  Foodtable Get(int id)
        {

            var fd = (from e in db.Foodtables
                     where e.Food_id == id
                     select e
                     );
            var f = db.Foodtables.FirstOrDefault(e => e.Food_id == id);
            return f;
        }

        public static List<Foodtable> GetAll()
        {
            var foodtables = db.Foodtables.ToList();
            return foodtables;

        }


    }
}