﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WikiReloaded2.Models;

namespace WikiReloaded2.Controllers
{
    public class ArticleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Article
        private Int64 id = 1;
        public ActionResult Index()
        {
            var articles = from article in db.Articles
                           orderby article.name
                           select article;
            ViewBag.Articles = articles;
            return View();
        }

        public ActionResult ShowCategory(string category)
        {
            var articles = from article in db.Articles
                           where article.category == category
                           orderby article.name
                           select article;
            ViewBag.Articles = articles;
            return View();
        }

        public ActionResult Show(int id)
        {
            Article article = db.Articles.Find(id);
            ViewBag.Article = article;
            return View();
        }

        public ActionResult New()
        {
            var categories = from category in db.Categories
                           orderby category.name
                           select category;
            ViewBag.Categories = categories;
            return View();
        }
        [HttpPost]
        public ActionResult New(Article article)
        {
            try
            {
                article.Id = id.ToString();
                id++;
                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (DbEntityValidationException e)
            {
                foreach (var validationErrors in e.EntityValidationErrors) {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Debug.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                
                return View();
            }
        }        public ActionResult Edit(string id)
        {
            Article article = db.Articles.Find(id);
            ViewBag.Article = article;
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, string name, string content)
        {
            Debug.WriteLine("ok1");
       
            try
            {
                Article article = db.Articles.Find(id.ToString());
                Debug.WriteLine("ok2");
                if (TryUpdateModel(article))
                {
                    Debug.WriteLine("ok3");
                    article.name = name;
                    article.content = content;
                    Debug.WriteLine("ok4");
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Debug.WriteLine(":(");
                return View();
            }
        }

        [HttpDelete]
        [Authorize(Roles = "Editor,Administrator")]
        public ActionResult Delete(int id)
        {
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}