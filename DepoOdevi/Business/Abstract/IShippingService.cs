using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface IShippingService
    {
        List<Shipping> GetList();
        Shipping GetById(int id);
        void ShippingAdd(Shipping shipping);
        void ShippingUpdate(Shipping shipping);
        void ShippingDelete(Shipping shipping);
        List<Shipping> GetListByFilter(Expression<Func<Shipping, bool>> filter);
    }
}