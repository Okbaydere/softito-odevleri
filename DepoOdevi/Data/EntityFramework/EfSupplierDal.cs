﻿using Data.Abstract;
using Data.Concrete;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EntityFramework
{
    public class EfSupplierDal:GenericRepository<Supplier>,ISupplierDal
    {
    }
}
