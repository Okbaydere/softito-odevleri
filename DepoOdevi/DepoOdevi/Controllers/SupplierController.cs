using Business.Concrete;
using Data.Concrete;
using Data.EntityFramework;
using Entity.Concrete;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class SupplierController : Controller
    {
        private readonly SupplierManager _supplierManager;

        public SupplierController()
        {
            _supplierManager = new SupplierManager(new EfSupplierDal());
        }

        public ActionResult Index()
        {
            var suppliers = _supplierManager.GetList();
            return View(suppliers);
        }

        public ActionResult Details(int id)
        {
            var supplier = _supplierManager.GetById(id);
            return View(supplier);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _supplierManager.SupplierAdd(supplier);
                return RedirectToAction("Index");
            }

            return View(supplier);
        }

        public ActionResult Edit(int id)
        {
            var supplier = _supplierManager.GetById(id);
            return View(supplier);
        }

        [HttpPost]
        public ActionResult Edit(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _supplierManager.SupplierUpdate(supplier);
                return RedirectToAction("Index");
            }
            return View(supplier);
        }

        public ActionResult Delete(int id)
        {
            var supplier = _supplierManager.GetById(id);
            return View(supplier);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var supplier = _supplierManager.GetById(id);
            _supplierManager.SupplierDelete(supplier);
            return RedirectToAction("Index");
        }
    }
}