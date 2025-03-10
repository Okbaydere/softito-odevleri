using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Business.Concrete;
using Data.Concrete;
using Entity.Concrete;
using System.Web.Mvc;
using Data.EntityFramework;

namespace UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryManager _categoryManager;

        public CategoryController()
        {
            _categoryManager = new CategoryManager(new EfCategoryDal());
        }

        public ActionResult Index()
        {
            var categories = _categoryManager.GetList();
            return View(categories);
        }

        public ActionResult Details(int id)
        {
            var category = _categoryManager.GetById(id);
            return View(category);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryManager.CategoryAdd(category);
                return RedirectToAction("Index");
            }

            return View(category);
        }

        public ActionResult Edit(int id)
        {
            var category = _categoryManager.GetById(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryManager.CategoryUpdate(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public ActionResult Delete(int id)
        {
            var category = _categoryManager.GetById(id);
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var category = _categoryManager.GetById(id);
            _categoryManager.CategoryDelete(category);
            return RedirectToAction("Index");
        }
    }
}