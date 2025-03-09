using Business.Concrete;
using Data.Concrete;
using Data.EntityFramework;
using Entity.Concrete;
using System;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeManager _employeeManager;

        public EmployeeController()
        {
            _employeeManager = new EmployeeManager(new EfEmployeeDal());
        }

        public ActionResult Index()
        {
            var employees = _employeeManager.GetList();
            return View(employees);
        }

        public ActionResult Details(int id)
        {
            var employee = _employeeManager.GetById(id);
            return View(employee);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.StartDate = DateTime.Now;
                _employeeManager.EmployeeAdd(employee);
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        public ActionResult Edit(int id)
        {
            var employee = _employeeManager.GetById(id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeManager.EmployeeUpdate(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        public ActionResult Delete(int id)
        {
            var employee = _employeeManager.GetById(id);
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var employee = _employeeManager.GetById(id);
            _employeeManager.EmployeeDelete(employee);
            return RedirectToAction("Index");
        }
    }
}