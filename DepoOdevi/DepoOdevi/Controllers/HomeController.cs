using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business.Concrete;
using Data.EntityFramework;
using Entity.Concrete;

namespace DepoUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductManager _productManager;
        private readonly StockMovementManager _stockMovementManager;
        private readonly ShippingManager _shippingManager;

        public HomeController()
        {
            _productManager = new ProductManager(new EfProductDal());
            _stockMovementManager = new StockMovementManager(new EfStockMovementDal());
            _shippingManager = new ShippingManager(new EfShippingDal());
        }

        public ActionResult Index()
        {
            ViewBag.LowStockProducts = _productManager.GetLowStockProducts();
            ViewBag.RecentMovements = _stockMovementManager.GetList().OrderByDescending(m => m.MovementDate).Take(5).ToList();
            ViewBag.PendingShipments = _shippingManager.GetList().Where(s => s.Status != "Teslim Edildi").ToList();
            
            return View();
        }
        
        public ActionResult LowStockProducts()
        {
            var lowStockProducts = _productManager.GetLowStockProducts();
            return View(lowStockProducts);
        }
        
        public ActionResult ReorderProducts()
        {
            var lowStockProducts = _productManager.GetLowStockProducts();
            return View(lowStockProducts);
        }
    }
}