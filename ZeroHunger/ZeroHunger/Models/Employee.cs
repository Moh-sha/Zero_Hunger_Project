//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZeroHunger.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public Employee()
        {
            this.Dashboards = new HashSet<Dashboard>();
        }
    
        public string E_Code { get; set; }
        public string E_name { get; set; }
    
        public virtual ICollection<Dashboard> Dashboards { get; set; }
    }
}
