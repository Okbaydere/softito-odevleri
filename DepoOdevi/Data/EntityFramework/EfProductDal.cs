using Data.Abstract;
using Data.Concrete;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Data.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public List<Product> GetLowStockProducts(int minStockLevel)
        {
            using (var context = new Context())
            {
                return context.Products
                    .Where(p => p.Stock <= p.MinimumStock || p.Stock <= minStockLevel)
                    .ToList();
            }
        }

        public List<Product> GetProductsWithCategory()
        {
            using (var context = new Context())
            {
                return context.Products
                    .Include(p => p.Category)
                    .ToList();
            }
        }

        public List<Product> GetProductsWithSupplier()
        {
            using (var context = new Context())
            {
                return context.Products
                    .Include(p => p.Supplier)
                    .ToList();
            }
        }
    }
}