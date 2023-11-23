using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ZeroHunger.Models;

namespace ZeroHunger.Repository
{
    public class OrderRepository
    {

        static ZeroHungerEntities db;
        static OrderRepository()
        {

            db = new ZeroHungerEntities();
        }



        public static void PlaceOrder(List<Foodtable> foodtables, string employee_id)
        {
            // Check if the employee ID is null or empty
            if (string.IsNullOrEmpty(employee_id))
            {
                // Handle the case where the employee ID is not provided (throw an exception, log an error, etc.)
                throw new ArgumentException("Employee ID is null or empty.", nameof(employee_id));
            }

            // Check if the employee exists
            var existingEmployee = db.Employees.FirstOrDefault(e => e.E_Code == employee_id);

            if (existingEmployee == null)
            {
                // Handle the case where the employee does not exist (throw an exception, log an error, etc.)
                throw new InvalidOperationException($"Employee with ID {employee_id} does not exist.");
            }

            // Employee exists, proceed with creating the Dashboard
            Dashboard dashboard = new Dashboard();
            dashboard.Amount = 1000;
            dashboard.Status = "Collected";
            dashboard.E_id = employee_id;

            // Rest of your code remains the same...
            db.Dashboards.Add(dashboard);
            db.SaveChanges();

            foreach (var f in foodtables)
            {
                var order = new Orderdetail()
                {
                    OrderId = dashboard.id,
                    Foodid = f.Food_id,
                    Unitprice = f.Food_price,
                    Qty = 1
                };

                db.Orderdetails.Add(order);
                db.SaveChanges();
            }
        }









    }
}