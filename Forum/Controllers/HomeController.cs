using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Forum.Models;
using Microsoft.AspNetCore.Http;

namespace Forum.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<TblPosts> posts = TblPosts.GetLast5Posts();

            ViewBag.ID = HttpContext.Session.GetInt32("ID");

            return View(posts);
        }

        public IActionResult LoginOrRegister()
        {
            ViewData["Message"] = "Login and registration page.";

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
