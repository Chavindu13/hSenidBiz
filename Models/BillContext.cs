using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace hSenidBiz.Models
{
    public class BillContext : DbContext
    {
        public BillContext()
            : base("name=BillContext")
        { }

        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Detail> Details { get; set; }
        public virtual DbSet<Product> Products { get; set; }
    }
}