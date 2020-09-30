using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.Mvc;
using WebBML.Repositories;
using WebDAL.DataModels;

namespace WebOnlineAuction.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Users> u;
        public HomeController()
        {
            u = new Repository<Users>();
        }

        public ActionResult Login() {

            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var result = u.Gets().SingleOrDefault(a => a.UserName.ToLower().Equals(username.ToLower()));
            if (result != null)
            {
                if (result.Password.ToLower().Equals(password.ToLower()))
                {
                    Session["user"] = result;
                    return RedirectToAction("Index","Items");
                }
                ViewBag.pwderr = "Password invalid!";
                return RedirectToAction("Login");
            }
            ViewBag.usnerr = "Account not exist!";
            return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult Register(Users user)
        {
            user.UserId = AutoGenId();
            user.Status = true;
            user.Created = DateTime.Now;
            if (u.Create(user))
                return Json(new { CodeStatus = 200, message = "Create user complete!" });
            return Json(new { CodeStatus = 200, message = "Create user faild!" });
        }

        public string AutoGenId() {
            int num = u.Gets().Count() + 1;
            string id = "USER";
            if (num < 10)
            {
                id = id + "0" + num;
            }
            else
            {
                id += num;
            }
            return id;
        }

        public ActionResult Logout() {
            Session.Remove("user");
           return RedirectToAction("Index", "Items");
        }
    }
}