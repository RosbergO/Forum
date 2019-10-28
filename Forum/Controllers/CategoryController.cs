using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Forum.Models;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Forum.Controllers
{
    public class Category : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create(string id)
        {
            if (HttpContext.Session.GetInt32("ID") != 4)
            {
                return RedirectToAction("Category", "posts");
            }
            int category = TblCategories.GetCategory(id);
            ViewBag.categoryID = category;
            ViewBag.category = id;
            return View();
        }

        [HttpPost]
        public IActionResult Create(TblCategories category)
        {
            if(HttpContext.Session.GetInt32("ID") != 4)
            {
                return RedirectToAction("Category", "posts");
            }
            string message = "";
            ViewBag.message = message;
            TblCategories.InsertCategory(category.CaName.ToString(), out message);
            return RedirectToAction("Posts/" + category.CaName, "Category");
        }
        public IActionResult Read()
        {
            List<TblCategories> categories = TblCategories.GetCategories();
            return PartialView(categories);
            /*
            TblCategories category = TblCategories.GetCategory(id);
            ViewBag.category = TblCategories.GetCategory(category.CaName);
            foreach (TblComments item in ViewBag.comments)
            {
                users[item.CoAuthor] = TblUser.GetUserFromID(item.CoAuthor).UsName;
            }
            ViewBag.users = users;
            return View(post);
            */
        }

        public IActionResult Posts(int id)
        {
            ViewBag.userList = new List<string>();
            List<TblPosts> postList = TblPosts.GetPostsFromCategory(id);
            string category = TblCategories.GetCategory(id);
            List<string> usernames = new List<string>();
            foreach (TblPosts posts in postList)
            {
                usernames.Add(TblUser.GetUserFromID(posts.PoAuthor).UsName);
            }
            ViewBag.postList = postList;
            ViewBag.category = category;
            ViewBag.usernames = usernames;
            
            return View(postList);
        }

        
    }

}

