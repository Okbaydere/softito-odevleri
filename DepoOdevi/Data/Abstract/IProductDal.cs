using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data.Abstract
{
    public interface IProductDal : IGenericRepository<Product>
    {
        List<Product> GetProductsWithCategory();
        List<Product> GetProductsWithSupplier();
        List<Product> GetLowStockProducts(int minStockLevel);
    }
}