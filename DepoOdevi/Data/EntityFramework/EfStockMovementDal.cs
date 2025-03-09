using Data.Abstract;
using Data.Concrete;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.EntityFramework
{
    public class EfStockMovementDal : GenericRepository<StockMovement>, IStockMovementDal
    {
    }
}