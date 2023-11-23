 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZeroHunger.Models;

namespace ZeroHunger.Repository
{
    public class NgoRepository
    {

        static ZeroHungerEntities db;

        static NgoRepository()
        {

            db = new ZeroHungerEntities();


        }

        public static Employee Get(string Code)
        {

            var emp = (from emply in db.Employees where emply.E_Code == Code select emply  ).FirstOrDefault();

            return emp;

        }

        public static Employee Authenticate(string Id,string password )
        {


            var emp = (from emply in db.Employees where emply.E_Code == Id && emply.E_name == password select emply).FirstOrDefault();

            return emp;

        }

    }
}