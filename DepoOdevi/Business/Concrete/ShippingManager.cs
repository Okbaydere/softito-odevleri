using Business.Abstract;
using Data.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class ShippingManager : IShippingService
    {
        private IShippingDal _shippingDal;

        public ShippingManager(IShippingDal shippingDal)
        {
            _shippingDal = shippingDal;
        }

        public void ShippingAdd(Shipping shipping)
        {
            _shippingDal.Insert(shipping);
        }

        public void ShippingDelete(Shipping shipping)
        {
            _shippingDal.Delete(shipping);
        }

        public void ShippingUpdate(Shipping shipping)
        {
            _shippingDal.Update(shipping);
        }

        public Shipping GetById(int id)
        {
            return _shippingDal.GetById(id);
        }

        public List<Shipping> GetList()
        {
            return _shippingDal.List();
        }

        public List<Shipping> GetListByFilter(Expression<Func<Shipping, bool>> filter)
        {
            return _shippingDal.List(filter);
        }
    }
}