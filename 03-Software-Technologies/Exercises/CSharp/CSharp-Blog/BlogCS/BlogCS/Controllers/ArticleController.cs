using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlogCS.Data;
using BlogCS.Models;
using Microsoft.AspNetCore.Authorization;

namespace BlogCS.Controllers
{
    public class ArticleController : Controller
    {
        private readonly ApplicationDbContext database;

        public ArticleController(ApplicationDbContext context)
        {
            database = context;
        }

        // GET: Article
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        //Get index of article
        public ActionResult List()
        {
            List<Article> articles = database.Articles
                .Include(a => a.Author)
                .ToList();

            return View(articles);
        }

        // GET: Article/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article =  database.Articles
                .Include(a => a.Author)
                .First(a => a.Id == id);

            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // GET: Article/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Article/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Article article)
        {
            if (ModelState.IsValid)
            {
                var authorId = database.Users
                    .Where(u => u.UserName == User.Identity.Name)
                    .FirstOrDefault()
                    .Id;

                article.AuthorId = authorId;

                database.Articles.Add(article);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(article);
        }

        // GET: Article/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = database.Articles
                .Where(a => a.Id == id)
                .Include(a => a.Author)
                .First();

            if(!IsAuthorized(article))
            {
                return Forbid();
            }

            var model = new ArticleViewModel(article);

            return View(model);
        }

        // POST: Article/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ArticleViewModel model)
        {
           if(ModelState.IsValid)
            {
                var article = database.Articles
                    .Where(a => a.Id == model.Id)
                    .Include(a => a.Author)
                    .FirstOrDefault();

                article.Title = model.Title;
                article.Content = model.Content;

                database.Update(article);
                database.SaveChanges();

                return RedirectToAction($"Details/{article.Id}");
            }

            return View(model);
        }

        // GET: Article/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = database.Articles
                .Include(a => a.Author)
                .First(a => a.Id == id);

            if (!IsAuthorized(article))
            {
                return Forbid();
            }

            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Article/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            var article = database.Articles
                .Include(a => a.Author)
                .First(a => a.Id == id);

            if (id == null)
            {
                return NotFound();
            }

            database.Articles.Remove(article);
            database.SaveChanges();

            return RedirectToAction("Index");
        }

        private bool ArticleExists(int id)
        {
            return database.Articles.Any(e => e.Id == id);
        }

        private bool IsAuthorized(Article article)
        {
            bool isAuthor = article.IsAuthor(User.Identity.Name);
            bool isAdmin = User.IsInRole("Admin");

            return isAdmin || isAuthor;
        }
    }
}
