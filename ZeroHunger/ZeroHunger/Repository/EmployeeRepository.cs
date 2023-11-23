using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZeroHunger.Models;

namespace ZeroHunger.Repository
{
    public class EmployeeRepository
    {


        static ZeroHungerEntities db;


        static EmployeeRepository()
        {


            db = new ZeroHungerEntities();
        }

        public static Dashboard Get(int id)
        {

            var fd = (from e in db.Dashboards
                      where e.Id == id
                      select e
                     );
            var es = db.Dashboards.FirstOrDefault(e => e.Id == id);
            return es;
        }
        public static List<Dashboard> GetAll()
        {
            var Dashboards = db.Dashboards.ToList();
            return Dashboards;

        }



    }
}