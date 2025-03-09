using Business.Concrete;
using Data.Concrete;
using Data.EntityFramework;
using Entity.Concrete;
using System;
using System.Linq;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class ShippingController : Controller
    {
        private readonly ShippingManager _shippingManager;
        private readonly StockMovementManager _stockMovementManager;
        private readonly EmployeeManager _employeeManager;
        private readonly ProductManager _productManager;

        public ShippingController()
        {
            _shippingManager = new ShippingManager(new EfShippingDal());
            _stockMovementManager = new StockMovementManager(new EfStockMovementDal());
            _employeeManager = new EmployeeManager(new EfEmployeeDal());
            _productManager = new ProductManager(new EfProductDal());
        }

        public ActionResult Index()
        {
            var shippings = _shippingManager.GetList();
            return View(shippings);
        }

      
        public ActionResult Details(int id)
        {
            var shipping = _shippingManager.GetById(id);
            return View(shipping);
        }

        public ActionResult Create()
        {
            ViewBag.EmployeeList = new SelectList(_employeeManager.GetList(), "EmployeeId", "FirstName");
            ViewBag.ProductList = new SelectList(_productManager.GetList(), "ProductId", "ProductName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Shipping shipping, int? productId, int? quantity, int? employeeId)
        {
            try
            {
                if (productId.HasValue && quantity.HasValue && quantity.Value > 0)
                {
                    if (!_stockMovementManager.IsStockAvailable(productId.Value, quantity.Value))
                    {
                        var product = _productManager.GetById(productId.Value);
                        ModelState.AddModelError("", $"Yeterli stok bulunmamaktadır! Ürün: {product.ProductName}, Mevcut Stok: {product.Stock}, İstenen Miktar: {quantity.Value}");
                        
                        ViewBag.EmployeeList = new SelectList(_employeeManager.GetList(), "EmployeeId", "FirstName");
                        ViewBag.ProductList = new SelectList(_productManager.GetList(), "ProductId", "ProductName");
                        return View(shipping);
                    }
                }

                if (ModelState.IsValid)
                {
                    shipping.ShipmentDate = DateTime.Now;
                    shipping.Status = "Hazırlanıyor";
                    _shippingManager.ShippingAdd(shipping);
                    
                    if (productId.HasValue && quantity.HasValue && quantity.Value > 0 && employeeId.HasValue)
                    {
                        try
                        {
                            CreateStockMovementForShipping(shipping.ShippingId, productId.Value, quantity.Value, employeeId.Value, shipping.TrackingNumber, "Çıkış");
                            TempData["SuccessMessage"] = "Kargo başarıyla oluşturuldu ve stok güncellendi.";
                        }
                        catch (InvalidOperationException ex)
                        {
                            TempData["WarningMessage"] = $"Kargo oluşturuldu ancak stok güncellenemedi: {ex.Message}";
                        }
                    }
                    
                    return RedirectToAction("Index");
                }
                
                ViewBag.EmployeeList = new SelectList(_employeeManager.GetList(), "EmployeeId", "FirstName");
                ViewBag.ProductList = new SelectList(_productManager.GetList(), "ProductId", "ProductName");
                return View(shipping);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Hata oluştu: " + ex.Message);
                ViewBag.EmployeeList = new SelectList(_employeeManager.GetList(), "EmployeeId", "FirstName");
                ViewBag.ProductList = new SelectList(_productManager.GetList(), "ProductId", "ProductName");
                return View(shipping);
            }
        }

        public ActionResult Edit(int id)
        {
            var shipping = _shippingManager.GetById(id);
            
            var stockMovement = FindStockMovementForShipping(id);
            if (stockMovement != null)
            {
                ViewBag.ProductId = stockMovement.ProductId;
                ViewBag.Quantity = stockMovement.Quantity;
                ViewBag.EmployeeId = stockMovement.EmployeeId;
            }
            
            ViewBag.EmployeeList = new SelectList(_employeeManager.GetList(), "EmployeeId", "FirstName");
            ViewBag.ProductList = new SelectList(_productManager.GetList(), "ProductId", "ProductName");
            return View(shipping);
        }

        [HttpPost]
        public ActionResult Edit(Shipping shipping, int? productId, int? quantity, int? employeeId)
        {
            try
            {
                var existingMovement = FindStockMovementForShipping(shipping.ShippingId);
                
                if (productId.HasValue && quantity.HasValue && quantity.Value > 0)
                {
                    bool needsStockCheck = false;
                    
                    if (existingMovement == null || existingMovement.ProductId != productId.Value)
                    {
                        needsStockCheck = true;
                    }
                    else if (existingMovement != null && existingMovement.ProductId == productId.Value && existingMovement.Quantity < quantity.Value)
                    {
                        needsStockCheck = true;
                    }
                    
                    if (needsStockCheck && !_stockMovementManager.IsStockAvailable(productId.Value, quantity.Value))
                    {
                        var product = _productManager.GetById(productId.Value);
                        ModelState.AddModelError("", $"Yeterli stok bulunmamaktadır! Ürün: {product.ProductName}, Mevcut Stok: {product.Stock}, İstenen Miktar: {quantity.Value}");
                        
                        ViewBag.ProductId = productId;
                        ViewBag.Quantity = quantity;
                        ViewBag.EmployeeId = employeeId;
                        ViewBag.EmployeeList = new SelectList(_employeeManager.GetList(), "EmployeeId", "FirstName");
                        ViewBag.ProductList = new SelectList(_productManager.GetList(), "ProductId", "ProductName");
                        return View(shipping);
                    }
                }

                if (ModelState.IsValid)
                {
                    _shippingManager.ShippingUpdate(shipping);
                    
                    if (productId.HasValue && quantity.HasValue && quantity.Value > 0 && employeeId.HasValue)
                    {
                        try
                        {
                            if (existingMovement != null)
                            {
                                existingMovement.ProductId = productId.Value;
                                existingMovement.Quantity = quantity.Value;
                                existingMovement.EmployeeId = employeeId.Value;
                                _stockMovementManager.StockMovementUpdate(existingMovement);
                            }
                            else
                            {
                                CreateStockMovementForShipping(shipping.ShippingId, productId.Value, quantity.Value, employeeId.Value, shipping.TrackingNumber, "Çıkış");
                            }
                            TempData["SuccessMessage"] = "Kargo başarıyla güncellendi ve stok güncellendi.";
                        }
                        catch (InvalidOperationException ex)
                        {
                            TempData["WarningMessage"] = $"Kargo güncellendi ancak stok güncellenemedi: {ex.Message}";
                        }
                    }
                    
                    return RedirectToAction("Index");
                }
                
                ViewBag.EmployeeList = new SelectList(_employeeManager.GetList(), "EmployeeId", "FirstName");
                ViewBag.ProductList = new SelectList(_productManager.GetList(), "ProductId", "ProductName");
                return View(shipping);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Hata oluştu: " + ex.Message);
                ViewBag.EmployeeList = new SelectList(_employeeManager.GetList(), "EmployeeId", "FirstName");
                ViewBag.ProductList = new SelectList(_productManager.GetList(), "ProductId", "ProductName");
                return View(shipping);
            }
        }

        public ActionResult Delete(int id)
        {
            var shipping = _shippingManager.GetById(id);
            return View(shipping);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var shipping = _shippingManager.GetById(id);
                
                var stockMovement = FindStockMovementForShipping(id);
                if (stockMovement != null)
                {
                    try
                    {
                        _stockMovementManager.StockMovementDelete(stockMovement);
                    }
                    catch (Exception ex)
                    {
                        TempData["WarningMessage"] = $"Stok hareketi silinirken hata oluştu: {ex.Message}";
                    }
                }
                
                _shippingManager.ShippingDelete(shipping);
                TempData["SuccessMessage"] = "Kargo başarıyla silindi.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Hata oluştu: " + ex.Message);
                return View(_shippingManager.GetById(id));
            }
        }

        public ActionResult ChangeStatus(int id, string status)
        {
            var shipping = _shippingManager.GetById(id);

            if (shipping != null)
            {
                shipping.Status = status;

                if (status == "Teslim Edildi")
                {
                    shipping.ArriveDate = DateTime.Now;
                }

                _shippingManager.ShippingUpdate(shipping);
                TempData["SuccessMessage"] = $"Kargo durumu '{status}' olarak güncellendi.";
            }

            return RedirectToAction("Index");
        }
        
        private void CreateStockMovementForShipping(int shippingId, int productId, int quantity, int employeeId, string trackingNumber, string movementType)
        {
            var stockMovement = new StockMovement
            {
                ProductId = productId,
                EmployeeId = employeeId,
                Quantity = quantity,
                MovementType = movementType,
                MovementDate = DateTime.Now,
                Description = $"Kargo ID: {shippingId} - {trackingNumber}"
            };
            
            _stockMovementManager.StockMovementAdd(stockMovement);
        }
        
        private StockMovement FindStockMovementForShipping(int shippingId)
        {
            var movements = _stockMovementManager.GetList();
            return movements.FirstOrDefault(m => m.Description != null && 
                                               m.Description.Contains($"Kargo ID: {shippingId}"));
        }
    }
}