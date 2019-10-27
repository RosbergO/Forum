using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Forum.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Forum.Controllers
{
    public class User : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TblUser user)
        {
            //hash the salt in user
            //we temporarily store the salted password in user.UsHash coming from the client
            user.UsHash = Convert.ToBase64String(Security.Security.Hash(Convert.FromBase64String(user.UsHash), Convert.FromBase64String(user.UsSalt)));
            Console.WriteLine("Create user POST {0}", user.ToString());
            TblUser.Insert(user, out string errorMessage);
            ViewBag.errorMessage = errorMessage;
            return RedirectToAction("index", "Home");
        }
    }
}
