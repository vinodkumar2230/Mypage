using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Mypage.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext()
            : base("MyConnectionstring")
        {
        }

        public DbSet<Employees> Employeess { get; set; }
        

    }
}