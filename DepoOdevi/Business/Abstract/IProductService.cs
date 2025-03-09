using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetList();
        void ProductAdd(Product product);
        void ProductDelete(Product product);
        void ProductUpdate(Product product);
        Product GetById(int id);
        List<Product> GetProductsByCategory(int categoryId);
        List<Product> GetProductsBySupplier(int supplierId);
        List<Product> GetProductsWithDetails();
    }
}
