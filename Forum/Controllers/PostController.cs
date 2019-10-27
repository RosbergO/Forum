using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Forum.Models;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Forum.Controllers
{
    public class PostController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search(string input)
        {
            List<TblPosts> post = TblPosts.GetPostsMatchingString(input);
            return View(post);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if(HttpContext.Session.GetInt32("ID") != TblPosts.GetPostFromID(id).PoAuthor)
            {
                return RedirectToAction("Login", "User");
            }
            string message = "";
            TblPosts.DeletePostFromID(id, out message);
            ViewBag.message = message;
            return RedirectToAction("index", "Home");
        }

        [HttpGet]
        public IActionResult Create(string id)
        {
            if (HttpContext.Session.GetInt32("ID") == null)
            {
                return RedirectToAction("Login", "User");
            }
            int category = TblCategories.GetCategory(id);
            ViewBag.categoryID = category;
            ViewBag.category = id;
            return View();
        }

        [HttpPost]
        public IActionResult Create(TblPosts post)
        {
            if (HttpContext.Session.GetInt32("ID") == null)
            {
                return RedirectToAction("Login", "User");
            }
            post.PoAuthor = int.Parse(HttpContext.Session.GetInt32("ID").ToString());
            string message = "";
            TblPosts.InsertPost(post, out message);
            ViewBag.message = message;
            return RedirectToAction("Posts/" + post.PoCategory, "Category");
        }

        public IActionResult Read(int id)
        {
            TblPosts post = TblPosts.GetPostFromID(id);
            ViewBag.category = TblCategories.GetCategory(post.PoCategory);
            ViewBag.comments = TblComments.GetCommentsFromID(post.PoId);
            Dictionary<int, string> users = new Dictionary<int, string>();
            foreach (TblComments item in ViewBag.comments)
            {
                users[item.CoAuthor] = TblUser.GetUserFromID(item.CoAuthor).UsName;
            }
            ViewBag.users = users;
            return View(post);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            TblPosts post = TblPosts.GetPostFromID(id);
            if(post.PoName == null || post.PoAuthor != HttpContext.Session.GetInt32("ID"))
            {
                return RedirectToAction("index", "Home");
            }
            return View(post);
        }

        [HttpPost]
        public IActionResult Edit(TblPosts post)
        {
            if (post.PoName == null || post.PoAuthor != HttpContext.Session.GetInt32("ID"))
            {
                return RedirectToAction("index", "Home");
            }
            string errorMessage = "";
            TblPosts.EditPost(post.PoId, post.PoName, post.PoContent, out errorMessage);
            ViewBag.message = errorMessage;
            return RedirectToAction("Read/" + post.PoId, "Post");
        }
    }
}
