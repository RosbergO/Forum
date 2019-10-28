using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Forum.Models;
using Microsoft.AspNetCore.Http;
using System.Net.Mail;
using System.Net;
using System.Text;
using Microsoft.IdentityModel.Protocols;

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
            while (true)
            {//keep generating new tokens if there already is a token with that name
                user.UsVerificationToken = Security.Security.get_unique_string(64).Replace('+', 'a');
                if (TblUser.GetUserFromToken(user.UsVerificationToken).UsName == null)
                    break;
            }

            Console.WriteLine("Create user POST {0}", user.ToString());
            TblUser.Insert(user, out string errorMessage);

            string verifyURL = @"/User/Verify/?token=" + user.UsVerificationToken;

            string link = $@"https://localhost:44316/{verifyURL}";
            string fromEmail = "monsterplanforum@gmail.com";
            string toEmail = user.UsEmail;
            string fromEmailPassword = "passwordisdees";
            string subject = "Verify your email today!";
            string body = "<br/><br/>We are excited to tell you that your Dotnet Awesome account is" +
        " successfully created. Please click on the below link to verify your account" +
        " <br/><br/><a href='" + link + "'>" + link + "</a>";
            int result = SendUserMail(fromEmail, toEmail, body, subject, subject);
            Console.WriteLine(result);
            ViewBag.errorMessage = errorMessage;
            return RedirectToAction("index", "Home");
        }

        [HttpGet]
        public IActionResult Login() => View();

        //removing [httppost] because we need to reach it from verify (a get request)
        public IActionResult Login(TblUser user)
        {


            TblUser serverUser = TblUser.GetUserFromName(user.UsName);
            if (serverUser.UsName == null)
            {
                ViewBag.errorMessage = "User doesn't exist.";
                return RedirectToAction("Login");
            }

            user.UsSalt = serverUser.UsSalt;
            byte[] salt = Convert.FromBase64String(user.UsSalt);
            user.UsHash = user.UsHash.PadLeft(20, 'a');
            byte[] password = Convert.FromBase64String(user.UsHash.ToString());
            user.UsHash = Convert.ToBase64String(Security.Security.Hash(password, salt));

            if (user.UsHash == serverUser.UsHash)
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

        [HttpGet]
        public IActionResult Verify(string token)
        {
            TblUser user = TblUser.GetUserFromToken(token);
            if (user.UsName == null || token == null || token.Length < 20)
            {
                return RedirectToAction("index", "home");
            }
            if (token == user.UsVerificationToken)
            {
                string errormessage = "";
                TblUser.VerifyUser(user, out errormessage);
                ViewBag.errormessage = errormessage;
                //key is correct, email verified, login user
                HttpContext.Session.SetInt32("ID", user.UsId);
                HttpContext.Session.SetString("Name", user.UsName);
            }

            return RedirectToAction("index", "Home");
        }
  
        [NonAction]
        public int SendUserMail(string fromad, string toad, string body, string header, string subjectcontent)
        {
            int result = 0;
            MailMessage usermail = Mailbodplain(fromad, toad, body, header, subjectcontent);
            SmtpClient client = new SmtpClient();
            //Add the Creddentials- use your own email id and password
            client.Credentials = new System.Net.NetworkCredential("monsterplanforum@gmail.com ", "passwordisdees"); ;

            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            try
            {
                client.Send(usermail);
                result = 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = 0;
            } // end try

            return result;

        }
        public MailMessage Mailbodplain(string fromad, string toad, string body, string header, string subjectcontent)
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            try
            {
                string from = fromad;
                string to = toad;
                mail.To.Add(to);
                mail.From = new MailAddress(from, header, System.Text.Encoding.UTF8);
                mail.Subject = subjectcontent;
                mail.SubjectEncoding = System.Text.Encoding.UTF8;
                mail.Body = body;
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;
            }
            catch (Exception ex)
            {
                throw;
            }
            return mail;

        }
    }
}
