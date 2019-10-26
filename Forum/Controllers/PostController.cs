using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Forum.Models;

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
        [HttpGet]
        public IActionResult Create(string id)
        {
            int category = TblCategories.GetCategory(id);
            ViewBag.categoryID = category;
            ViewBag.category = id;
            return View();
        }

        [HttpPost]
        public IActionResult Create(TblPosts post)
        {
            string message = "";
            TblPosts.InsertPost(post, out message);
            ViewBag.message = message;
            return View();

        }
    }
}
