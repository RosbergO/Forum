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
    public class User : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Read(int id)
        {
            TblUser user = TblUser.GetUserFromID(id);
            return View(user);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TblUser user)
        {
            //hash the salt in user
            user.UsSalt = Convert.ToBase64String(Security.Security.Salt());
            user.UsSalt = user.UsSalt.Substring(0, 128);
            //we temporarily store the salted password in user.UsHash coming from the client
            byte[] salt = Convert.FromBase64String(user.UsSalt);
            user.UsHash = user.UsHash.PadLeft(20, 'a');
            byte[] password = Convert.FromBase64String(user.UsHash.ToString());
            user.UsHash = Convert.ToBase64String(Security.Security.Hash(password, salt));
            Console.WriteLine("Create user POST {0}", user.ToString());
            TblUser.Insert(user, out string errorMessage);
            ViewBag.errorMessage = errorMessage;
            return RedirectToAction("index", "Home");
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(TblUser user)
        {


            TblUser serverUser = TblUser.GetUserFromName(user.UsName);
            if(serverUser.UsName == null)
            {
                ViewBag.errorMessage = "User doesn't exist.";
                return RedirectToAction("Login");
            }

            user.UsSalt = serverUser.UsSalt;
            byte[] salt = Convert.FromBase64String(user.UsSalt);
            user.UsHash = user.UsHash.PadLeft(20, 'a');
            byte[] password = Convert.FromBase64String(user.UsHash.ToString());
            user.UsHash = Convert.ToBase64String(Security.Security.Hash(password, salt));

            if(user.UsHash == serverUser.UsHash)
            {
                HttpContext.Session.SetInt32("ID", serverUser.UsId);
                HttpContext.Session.SetString("Name", serverUser.UsName);
                return RedirectToAction("index", "Home");
            }
            else
            {
                ViewBag.errorMessage = "Incorrect password";
                return RedirectToAction("Login");
            }
        }

        [HttpGet]
        public IActionResult Logout()
        {
            if (HttpContext.Session.GetInt32("ID") != null)
            {
                HttpContext.Session.Remove("ID");
                HttpContext.Session.Remove("Name");

            }
            return RedirectToAction("index", "Home");
        }
        

    }
}
