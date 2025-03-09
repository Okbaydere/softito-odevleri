using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface ISupplierService
    {
        List<Supplier> GetList();
        Supplier GetById(int id);
        void SupplierAdd(Supplier supplier);
        void SupplierUpdate(Supplier supplier);
        void SupplierDelete(Supplier supplier);
        List<Supplier> GetListByFilter(Expression<Func<Supplier, bool>> filter);
    }
}