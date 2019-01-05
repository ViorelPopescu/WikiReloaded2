using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WikiReloaded2.Models;

namespace WikiReloaded2.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class CategoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private int id = 0;
        // GET: Category
        public ActionResult Index()
        {
            var categories = from category in db.Categories
                             orderby category.name
                             select category;
            ViewBag.Categories = categories;
            return View();
        }

        public ActionResult New()
        {
            return View();
        }
        [HttpPost]
        public ActionResult New(Category category)
        {
            try
            {
                category.Id = id.ToString();
                id++;
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }
    }
}