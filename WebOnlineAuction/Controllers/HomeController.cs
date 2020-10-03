using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using WebBML.Repositories;
using WebDAL.DataModels;
using WebDML.ViewModels;

namespace WebOnlineAuction.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Users> u;
        IRepository<Category> cat;
        IRepository<Rating> rate;
        IRepository<Users> us;
        public HomeController()
        {
            u = new Repository<Users>();
            cat = new Repository<Category>();
            rate = new Repository<Rating>();
            us = new Repository<Users>();
            var c = cat.Gets();
            ViewBag.cats = c;
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
            user.Rate = 0;
            if (u.Create(user))
                return Json(new { CodeStatus = 200, message = "Create user complete!" });
            return Json(new { CodeStatus = 200, message = "Create user faild!" });
        }

        [HttpGet]
        public ActionResult Edit(string id) {
            var data = u.Get(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Users user)
        {
            var target = u.Get(user.UserId);
            target.Email = user.Email;
            target.Password = user.Password;
            target.Phone = user.Phone;
            target.Updated = DateTime.Now;
            u.Update(target);
            return RedirectToAction("Edit","Home",new { id = user.UserId });
        }

        // Show up all rating user have
        [HttpGet]
        public ActionResult GetRate(string id)
        {
            var data = rate.Gets(x => x.ToId.Equals(id));
            ViewBag.rates = data;
            ViewBag.toid = id;
            return View();
        }

        [HttpPost]
        public ActionResult LeaveRate( string toId,int rnum , string comment) {
            Users u = Session["user"] as Users;
            var data = rate.Gets(x => x.FromId == u.UserId).Where(x => x.ToId == toId).FirstOrDefault();
            if (data != null)
            {
                data.Rate = rnum;
                data.Comment = comment;
                rate.Update(data);
                var pdata = rate.Gets(x => x.ToId == toId);
                var user = us.Get(toId);
                int i = 0;
                if (pdata.Count() > 0)
                {
                    i += pdata.Sum(x => x.Rate);
                }
                if (i > 5)
                {
                    i = 5;
                }
                else if (i < -5)
                {
                    i = -5;
                }
                user.Rate = i / pdata.Count();
                us.Update(user);
                return RedirectToAction("GetRate", "Home", new { id = toId });
            }
            else
            {
                Rating r = new Rating();
                r.FromId = u.UserId;
                r.ToId = toId;
                r.Rate = rnum;
                r.Comment = comment;
                r.Created = DateTime.Now;
                if (rate.Create(r))
                {
                    var pdata = rate.Gets(x => x.ToId == toId);
                    var user = us.Get(toId);
                    int i = 0;
                    if (pdata.Count() > 0)
                    {
                        i += pdata.Sum(x => x.Rate);
                    }
                    if (i > 5)
                    {
                        i = 5;
                    }
                    else if(i < -5)
                    {
                        i = -5;
                    }
                    user.Rate = i/pdata.Count();
                    us.Update(user);
                    return RedirectToAction("GetRate", "Home", new { id = toId });
                }
                return View("~/Views/Shared/Error.cshtml");
            }
        }

        //auto generation id type string for new user 
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
           return RedirectToAction("Login");
        }


    }
}