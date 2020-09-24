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
        public ActionResult Login(string username ,string password)
        {
            var result = u.Gets().FirstOrDefault(a => a.UserName.Equals(username));
            if (result != null)
            {
                if (result.Password.ToLower().Equals(password.ToLower()))
                {
                    Session["user"] = result;
                    return Json(new { status = true, message = "Login Successfull!" });
                }
                return Json(new { status = false, message = "Password invalid!" });
            }
            return Json(new { status = false, message = "Account not exist!" });
        }

        [HttpPost]
        public ActionResult Register(Users user)
        {
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
            user.UserId = id;
            user.Created = DateTime.Now;
            if (u.Create(user))
                return Json(new { CodeStatus = 200, message = "Create user complete!" });
            return Json(new { CodeStatus = 200, message = "Create user faild!" });
        }

        public ActionResult Contact() {
            return View();
        }

        public ActionResult DetailItem() {
            return View();
        }

        public ActionResult ListItem() {
            return View();
        }
    }
}