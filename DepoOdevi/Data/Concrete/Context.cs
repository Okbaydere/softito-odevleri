using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete
{
   public class Context:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Shipping> Shippings { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<StockMovement> StockMovements { get; set; }
    }
}
