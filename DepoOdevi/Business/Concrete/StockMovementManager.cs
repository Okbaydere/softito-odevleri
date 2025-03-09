using Business.Abstract;
using Data.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class StockMovementManager : IStockMovementService
    {
        private IStockMovementDal _stockMovementDal;
        private IProductDal _productDal;

        public StockMovementManager(IStockMovementDal stockMovementDal)
        {
            _stockMovementDal = stockMovementDal;
            _productDal = new Data.EntityFramework.EfProductDal();
        }

        public void StockMovementAdd(StockMovement stockMovement)
        {
            if (!UpdateProductStock(stockMovement))
            {
                throw new InvalidOperationException($"Ürün ID: {stockMovement.ProductId} için yeterli stok bulunmamaktadır. Mevcut stok: {GetProductCurrentStock(stockMovement.ProductId)}, İstenen miktar: {stockMovement.Quantity}");
            }
            
            _stockMovementDal.Insert(stockMovement);
        }

        public void StockMovementDelete(StockMovement stockMovement)
        {
            ReverseProductStock(stockMovement);
            
            _stockMovementDal.Delete(stockMovement);
        }

        public void StockMovementUpdate(StockMovement stockMovement)
        {
            var oldStockMovement = _stockMovementDal.GetById(stockMovement.StockMovementId);
            
            ReverseProductStock(oldStockMovement);
            
            if (!UpdateProductStock(stockMovement))
            {
                UpdateProductStock(oldStockMovement);
                throw new InvalidOperationException($"Ürün ID: {stockMovement.ProductId} için yeterli stok bulunmamaktadır. Mevcut stok: {GetProductCurrentStock(stockMovement.ProductId)}, İstenen miktar: {stockMovement.Quantity}");
            }
            
            _stockMovementDal.Update(stockMovement);
        }

        public StockMovement GetById(int id)
        {
            return _stockMovementDal.GetById(id);
        }

        public List<StockMovement> GetList()
        {
            return _stockMovementDal.List();
        }

        public List<StockMovement> GetListByFilter(Expression<Func<StockMovement, bool>> filter)
        {
            return _stockMovementDal.List(filter);
        }

        public List<StockMovement> GetStockMovementsByProduct(int productId)
        {
            return _stockMovementDal.List(s => s.ProductId == productId);
        }

        public List<StockMovement> GetStockMovementsByEmployee(int employeeId)
        {
            return _stockMovementDal.List(s => s.EmployeeId == employeeId);
        }

        public int GetProductCurrentStock(int productId)
        {
            var product = _productDal.GetById(productId);
            return product != null ? product.Stock : 0;
        }
        
        private bool UpdateProductStock(StockMovement stockMovement)
        {
            var product = _productDal.GetById(stockMovement.ProductId);
            if (product != null)
            {
                switch (stockMovement.MovementType)
                {
                    case "Giriş":
                    case "İade":
                        product.Stock += stockMovement.Quantity;
                        if (stockMovement.MovementType == "Giriş")
                        {
                            product.LastPurchaseDate = DateTime.Now;
                        }
                        break;
                    case "Çıkış":
                    case "Satış":
                        if (product.Stock >= stockMovement.Quantity)
                        {
                            product.Stock -= stockMovement.Quantity;
                        }
                        else
                        {
                            return false;
                        }
                        break;
                    case "Sayım":
                        product.Stock = stockMovement.Quantity;
                        break;
                }
                
                _productDal.Update(product);
                return true;
            }
            return false;
        }
        
        private void ReverseProductStock(StockMovement stockMovement)
        {
            var product = _productDal.GetById(stockMovement.ProductId);
            if (product != null)
            {
                switch (stockMovement.MovementType)
                {
                    case "Giriş":
                    case "İade":
                        if (product.Stock >= stockMovement.Quantity)
                        {
                            product.Stock -= stockMovement.Quantity;
                        }
                        break;
                    case "Çıkış":
                    case "Satış":
                        product.Stock += stockMovement.Quantity;
                        break;
                    case "Sayım":
                        break;
                }
                
                _productDal.Update(product);
            }
        }

        public bool IsStockAvailable(int productId, int quantity)
        {
            var product = _productDal.GetById(productId);
            return product != null && product.Stock >= quantity;
        }
    }
}