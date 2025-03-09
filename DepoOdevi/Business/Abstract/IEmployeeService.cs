using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entity.Concrete;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface IEmployeeService
    {
        List<Employee> GetList();
        Employee GetById(int id);
        void EmployeeAdd(Employee employee);
        void EmployeeUpdate(Employee employee);
        void EmployeeDelete(Employee employee);
        List<Employee> GetListByFilter(Expression<Func<Employee, bool>> filter);
    }
}