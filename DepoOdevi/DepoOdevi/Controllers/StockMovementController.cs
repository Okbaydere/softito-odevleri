using Business.Concrete;
using Data.Concrete;
using Data.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class StockMovementController : Controller
    {
        private readonly StockMovementManager _stockMovementManager;
        private readonly ProductManager _productManager;
        private readonly EmployeeManager _employeeManager;

        public StockMovementController()
        {
            _stockMovementManager = new StockMovementManager(new EfStockMovementDal());
            _productManager = new ProductManager(new EfProductDal());
            _employeeManager = new EmployeeManager(new EfEmployeeDal());
        }

        // GET: StockMovement
        public ActionResult Index()
        {
            var stockMovements = _stockMovementManager.GetList();
            return View(stockMovements);
        }

        // GET: StockMovement/Details/5
        public ActionResult Details(int id)
        {
            var stockMovement = _stockMovementManager.GetById(id);
            return View(stockMovement);
        }

        // GET: StockMovement/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(_productManager.GetList(), "ProductId", "ProductName");
            ViewBag.EmployeeId = new SelectList(_employeeManager.GetList(), "EmployeeId", "FirstName");
            ViewBag.MovementTypes = new List<SelectListItem>
            {
                new SelectListItem { Text = "Giriş", Value = "Giriş" },
                new SelectListItem { Text = "Çıkış", Value = "Çıkış" },
                new SelectListItem { Text = "Sayım", Value = "Sayım" },
                new SelectListItem { Text = "Satış", Value = "Satış" },
                new SelectListItem { Text = "İade", Value = "İade" }
            };

            return View();
        }

        // POST: StockMovement/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StockMovement stockMovement)
        {
            if (ModelState.IsValid)
            {
                stockMovement.MovementDate = DateTime.Now;
                _stockMovementManager.StockMovementAdd(stockMovement);
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(_productManager.GetList(), "ProductId", "ProductName", stockMovement.ProductId);
            ViewBag.EmployeeId = new SelectList(_employeeManager.GetList(), "EmployeeId", "FirstName", stockMovement.EmployeeId);
            ViewBag.MovementTypes = new List<SelectListItem>
            {
                new SelectListItem { Text = "Giriş", Value = "Giriş", Selected = stockMovement.MovementType == "Giriş" },
                new SelectListItem { Text = "Çıkış", Value = "Çıkış", Selected = stockMovement.MovementType == "Çıkış" },
                new SelectListItem { Text = "Sayım", Value = "Sayım", Selected = stockMovement.MovementType == "Sayım" },
                new SelectListItem { Text = "Satış", Value = "Satış", Selected = stockMovement.MovementType == "Satış" },
                new SelectListItem { Text = "İade", Value = "İade", Selected = stockMovement.MovementType == "İade" }
            };

            return View(stockMovement);
        }

        // GET: StockMovement/Edit/5
        public ActionResult Edit(int id)
        {
            var stockMovement = _stockMovementManager.GetById(id);

            ViewBag.ProductId = new SelectList(_productManager.GetList(), "ProductId", "ProductName", stockMovement.ProductId);
            ViewBag.EmployeeId = new SelectList(_employeeManager.GetList(), "EmployeeId", "FirstName", stockMovement.EmployeeId);
            ViewBag.MovementTypes = new List<SelectListItem>
            {
                new SelectListItem { Text = "Giriş", Value = "Giriş", Selected = stockMovement.MovementType == "Giriş" },
                new SelectListItem { Text = "Çıkış", Value = "Çıkış", Selected = stockMovement.MovementType == "Çıkış" },
                new SelectListItem { Text = "Sayım", Value = "Sayım", Selected = stockMovement.MovementType == "Sayım" },
                new SelectListItem { Text = "Satış", Value = "Satış", Selected = stockMovement.MovementType == "Satış" },
                new SelectListItem { Text = "İade", Value = "İade", Selected = stockMovement.MovementType == "İade" }
            };

            return View(stockMovement);
        }

        // POST: StockMovement/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StockMovement stockMovement)
        {
            if (ModelState.IsValid)
            {
                _stockMovementManager.StockMovementUpdate(stockMovement);
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(_productManager.GetList(), "ProductId", "ProductName", stockMovement.ProductId);
            ViewBag.EmployeeId = new SelectList(_employeeManager.GetList(), "EmployeeId", "FirstName", stockMovement.EmployeeId);
            ViewBag.MovementTypes = new List<SelectListItem>
            {
                new SelectListItem { Text = "Giriş", Value = "Giriş", Selected = stockMovement.MovementType == "Giriş" },
                new SelectListItem { Text = "Çıkış", Value = "Çıkış", Selected = stockMovement.MovementType == "Çıkış" },
                new SelectListItem { Text = "Sayım", Value = "Sayım", Selected = stockMovement.MovementType == "Sayım" },
                new SelectListItem { Text = "Satış", Value = "Satış", Selected = stockMovement.MovementType == "Satış" },
                new SelectListItem { Text = "İade", Value = "İade", Selected = stockMovement.MovementType == "İade" }
            };

            return View(stockMovement);
        }

        // GET: StockMovement/Delete/5
        public ActionResult Delete(int id)
        {
            var stockMovement = _stockMovementManager.GetById(id);
            return View(stockMovement);
        }

        // POST: StockMovement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var stockMovement = _stockMovementManager.GetById(id);
            _stockMovementManager.StockMovementDelete(stockMovement);
            return RedirectToAction("Index");
        }

        // GET: StockMovement/ProductStock/5
        public ActionResult ProductStock(int id)
        {
            var product = _productManager.GetById(id);
            ViewBag.Product = product;
            ViewBag.CurrentStock = _stockMovementManager.GetProductCurrentStock(id);
            var movements = _stockMovementManager.GetStockMovementsByProduct(id);
            return View(movements);
        }

        // GET: StockMovement/EmployeeMovements/5
        public ActionResult EmployeeMovements(int id)
        {
            var employee = _employeeManager.GetById(id);
            ViewBag.Employee = employee;
            var movements = _stockMovementManager.GetStockMovementsByEmployee(id);
            return View(movements);
        }
    }
}