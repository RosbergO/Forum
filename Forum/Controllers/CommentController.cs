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
    public class CommentController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            ViewBag.PostID = id;
            return PartialView();
        }

        [HttpPost]
        public IActionResult Create(TblComments comment)
        {
            if(HttpContext.Session.GetInt32("ID") == null)
            {
                return RedirectToAction("read/" + comment.CoPost, "Post");
            }
            string message = "";
            TblComments.InsertComment(comment, out message);
            ViewBag.message = message;
            return RedirectToAction("read/" + comment.CoPost, "Post");
        }

    }
}
