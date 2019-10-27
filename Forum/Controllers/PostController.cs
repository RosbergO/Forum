﻿using System;
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

        public IActionResult Search(string input)
        {
            List<TblPosts> post = TblPosts.GetPostsMatchingString(input);
            return View(post);
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

        public IActionResult Edit()
        {

            return View();
        }
    }
}
