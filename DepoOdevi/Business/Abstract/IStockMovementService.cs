using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface IStockMovementService
    {
        List<StockMovement> GetList();
        StockMovement GetById(int id);
        void StockMovementAdd(StockMovement stockMovement);
        void StockMovementUpdate(StockMovement stockMovement);
        void StockMovementDelete(StockMovement stockMovement);
        List<StockMovement> GetListByFilter(Expression<Func<StockMovement, bool>> filter);
        List<StockMovement> GetStockMovementsByProduct(int productId);
        List<StockMovement> GetStockMovementsByEmployee(int employeeId);
        int GetProductCurrentStock(int productId);
    }
}