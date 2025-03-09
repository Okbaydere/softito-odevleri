using Business.Abstract;
using Data.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class SupplierManager : ISupplierService
    {
        private ISupplierDal _supplierDal;

        public SupplierManager(ISupplierDal supplierDal)
        {
            _supplierDal = supplierDal;
        }

        public void SupplierAdd(Supplier supplier)
        {
            _supplierDal.Insert(supplier);
        }

        public void SupplierDelete(Supplier supplier)
        {
            _supplierDal.Delete(supplier);
        }

        public void SupplierUpdate(Supplier supplier)
        {
            _supplierDal.Update(supplier);
        }

        public Supplier GetById(int id)
        {
            return _supplierDal.GetById(id);
        }

        public List<Supplier> GetList()
        {
            return _supplierDal.List();
        }

        public List<Supplier> GetListByFilter(Expression<Func<Supplier, bool>> filter)
        {
            return _supplierDal.List(filter);
        }
    }
}