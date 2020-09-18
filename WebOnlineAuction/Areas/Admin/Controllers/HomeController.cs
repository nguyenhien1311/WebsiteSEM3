using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Web.UI.WebControls;
using WebBML.Repositories;
using WebDAL.DataModels;
using WebDAL.ViewModels;

namespace WebOnlineAuction.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {

        IRepository<Administrator> ad;

        public HomeController()
        {
            ad = new Repository<Administrator>();

            Administrator test = new Administrator();
            test.AdminId = "AD01";
            test.LoginName = "Admin1";
            test.Password = "admin";
            ad.Create(test);
        }

        // GET: Admin/Home
        public ActionResult Index()
        {
            Administrator check = Session["admin"] as Administrator;
            if (check != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }

        }

        // get all the admin in db and change to admin view model
        [HttpGet]
        public ActionResult GetAll()
        {
            var data = ad.Gets().Select(a => new AdminViewModel
            {
                AdminId = a.AdminId,
                LoginName = a.LoginName,
                Password = a.Password,
                Created = a.Created,
                Status = a.Status
            });
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //go to login view
        public ActionResult Login()
        {
            return View();
        }

        // process login in the admin page and save info to session
        [HttpPost]
        public ActionResult Login(string loginName, string password)
        {
            var result = ad.Gets().SingleOrDefault(a => a.LoginName.Equals(loginName));
            if (result != null)
            {
                if (result.Password.ToLower().Equals(password.ToLower()))
                {
                    var current = Session["admin"];
                    if (current == null)
                    {
                        Session["admin"] = result;
                    }
                    return Json(new { status = true, message = "Login Successfull!" });
                }
                return Json(new { status = false, message = "Password invalid!" });
            }
            return Json(new { status = false, message = "Account not exist!" });
        }

        //create a admin 
        [HttpPost]
        public ActionResult Create(Administrator admin)
        {
            int num = ad.Gets().Count();
            string id = "AD";
            if (num < 10)
            {
                id = id + "0" + num;
            }
            else
            {
                id += num;
            }
            admin.AdminId = id;
            admin.Created = DateTime.Now;
            if (ad.Create(admin))
                return Json(new { CodeStatus = 200, message = "Create account complete!" });
            return Json(new { CodeStatus = 200, message = "Create account faild!" });
        }

        // get admin detail by id
        [HttpGet]
        public ActionResult Update(string id)
        {
            return Json(new { CodeStatus = 200, Data = ad.Get(id) });
        }
        // edit admin's info with new info
        [HttpPost]
        public ActionResult Update(Administrator admin)
        {
            if (ad.Update(admin))
                return Json(new { CodeStatus = 200, message = "Update complete!" });
            return Json(new { CodeStatus = 200, message = "Update faild!" });
        }

        // delete a admin 
        [HttpDelete]
        public ActionResult Delete(string id)
        {
            ad.Remove(id);
            return Json(new
            {
                message = "Delete complete!",
                status = true
            });
        }

        // clear session and rediect to login gage
        public ActionResult Logout()
        {
            Session.Remove("admin");
            return RedirectToAction("Login");
        }

    }
}