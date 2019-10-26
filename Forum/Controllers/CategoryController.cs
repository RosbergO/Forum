﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Forum.Models;

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

