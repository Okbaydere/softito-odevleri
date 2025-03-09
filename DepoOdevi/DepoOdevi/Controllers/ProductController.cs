using Business.Concrete;
using Data.Concrete;
using Data.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DepoUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductManager productManager;
        private readonly CategoryManager categoryManager;
        private readonly SupplierManager supplierManager;
        private readonly StockMovementManager stockMovementManager;
        private readonly EmployeeManager employeeManager;

        public ProductController()
        {
            productManager = new ProductManager(new EfProductDal());
            categoryManager = new CategoryManager(new EfCategoryDal());
            supplierManager = new SupplierManager(new EfSupplierDal());
            stockMovementManager = new StockMovementManager(new EfStockMovementDal());
            employeeManager = new EmployeeManager(new EfEmployeeDal());
        }

        public ActionResult Index()
        {
            var productValues = productManager.GetProductsWithDetails();
            return View(productValues);
        }

        public ActionResult Details(int id)
        {
            var productValue = productManager.GetById(id);
            return View(productValue);
        }

        public ActionResult Create()
        {
            PopulateDropdownLists();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    productManager.ProductAdd(product);
                    return RedirectToAction("Index");
                }

                PopulateDropdownLists();
                return View(product);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Hata oluştu: " + ex.Message);
                PopulateDropdownLists();
                return View(product);
            }
        }

        public ActionResult Edit(int id)
        {
            PopulateDropdownLists();
            var productValue = productManager.GetById(id);
            return View(productValue);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    productManager.ProductUpdate(product);
                    return RedirectToAction("Index");
                }

                PopulateDropdownLists();
                return View(product);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Hata oluştu: " + ex.Message);
                PopulateDropdownLists();
                return View(product);
            }
        }

        public ActionResult Delete(int id)
        {
            var productValue = productManager.GetById(id);
            return View(productValue);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var product = productManager.GetById(id);
                productManager.ProductDelete(product);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Hata oluştu: " + ex.Message);
                return View(productManager.GetById(id));
            }
        }

  

        
        public ActionResult StockCount()
        {
            var products = productManager.GetList();
            ViewBag.EmployeeList = employeeManager.GetList()
                .Select(x => new SelectListItem
                {
                    Text = x.FirstName + " " + x.LastName,
                    Value = x.EmployeeId.ToString()
                }).ToList();
            return View(products);
        }
        
        [HttpPost]
        public ActionResult StockCount(FormCollection form)
        {
            try
            {
                int employeeId = Convert.ToInt32(form["EmployeeId"]);
                string description = form["Description"] ?? "Stok Sayımı";
                
                foreach (var key in form.AllKeys)
                {
                    if (key.StartsWith("count_"))
                    {
                        int productId = Convert.ToInt32(key.Replace("count_", ""));
                        int newCount = Convert.ToInt32(form[key]);
                        
                        var product = productManager.GetById(productId);
                        if (product != null)
                        {
                            var stockMovement = new StockMovement
                            {
                                ProductId = productId,
                                EmployeeId = employeeId,
                                Quantity = newCount,
                                MovementType = "Sayım",
                                MovementDate = DateTime.Now,
                                Description = description
                            };
                            
                            stockMovementManager.StockMovementAdd(stockMovement);
                        }
                    }
                }
                
                TempData["Message"] = "Stok sayımı başarıyla tamamlandı.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Hata oluştu: " + ex.Message;
                return RedirectToAction("StockCount");
            }
        }

        private void PopulateDropdownLists()
        {
            ViewBag.CategoryList = categoryManager.GetList()
                .Select(x => new SelectListItem
                {
                    Text = x.CategoryName,
                    Value = x.CategoryId.ToString()
                }).ToList();

            ViewBag.SupplierList = supplierManager.GetList()
                .Select(x => new SelectListItem
                {
                    Text = x.CompanyName,
                    Value = x.SupplierId.ToString()
                }).ToList();
        }
    }
}