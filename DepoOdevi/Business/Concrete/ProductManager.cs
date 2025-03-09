using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Data.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetList()
        {
            return _productDal.List();
        }

        public void ProductAdd(Product product)
        {
            if (string.IsNullOrEmpty(product.ProductName))
            {
                throw new Exception("Ürün adı boş olamaz!");
            }

            if (product.SalePrice <= 0)
            {
                throw new Exception("Satış fiyatı sıfırdan büyük olmalıdır!");
            }

            _productDal.Insert(product);
        }

        public void ProductDelete(Product product)
        {
            _productDal.Delete(product);
        }

        public void ProductUpdate(Product product)
        {
            if (string.IsNullOrEmpty(product.ProductName))
            {
                throw new Exception("Ürün adı boş olamaz!");
            }

            if (product.SalePrice <= 0)
            {
                throw new Exception("Satış fiyatı sıfırdan büyük olmalıdır!");
            }

            _productDal.Update(product);
            
            CheckLowStock(product);
        }

        public Product GetById(int id)
        {
            return _productDal.GetById(id);
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            return _productDal.List(p => p.CategoryId == categoryId);
        }

        public List<Product> GetProductsBySupplier(int supplierId)
        {
            return _productDal.List(p => p.SupplierId == supplierId);
        }

        public List<Product> GetProductsWithDetails()
        {
            return _productDal.GetProductsWithCategory();
        }
        
        public List<Product> GetLowStockProducts()
        {
            return _productDal.List(p => p.Stock <= p.MinimumStock);
        }
        
        private void CheckLowStock(Product product)
        {
            if (product.Stock <= product.MinimumStock)
            {
                System.Diagnostics.Debug.WriteLine($"UYARI: {product.ProductName} ürününün stok seviyesi kritik! Mevcut stok: {product.Stock}, Minimum stok: {product.MinimumStock}");
            }
        }
    }
}