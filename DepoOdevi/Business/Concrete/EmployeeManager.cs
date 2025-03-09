using Business.Abstract;
using Data.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        private IEmployeeDal _employeeDal;

        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        public void EmployeeAdd(Employee employee)
        {
            _employeeDal.Insert(employee);
        }

        public void EmployeeDelete(Employee employee)
        {
            _employeeDal.Delete(employee);
        }

        public void EmployeeUpdate(Employee employee)
        {
            _employeeDal.Update(employee);
        }

        public Employee GetById(int id)
        {
            return _employeeDal.GetById(id);
        }

        public List<Employee> GetList()
        {
            return _employeeDal.List();
        }

        public List<Employee> GetListByFilter(Expression<Func<Employee, bool>> filter)
        {
            return _employeeDal.List(filter);
        }
    }
}