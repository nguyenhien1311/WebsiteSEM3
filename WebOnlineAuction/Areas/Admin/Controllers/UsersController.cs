
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using WebBML.Repositories;
using WebDAL.DataModels;
using WebDAL.ViewModels;
using WebDML.ViewModels;

namespace WebOnlineAuction.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        IRepository<Users> u;
        IRepository<Items> item;
        IRepository<BidLog> bl;
        IRepository<Orders> ods;
        IRepository<Rating> rate;

        public UsersController()
        {
            u = new Repository<Users>();
            item = new Repository<Items>();
            bl = new Repository<BidLog>();
            ods = new Repository<Orders>();
            rate = new Repository<Rating>();
        }

        // GET: Admin/Users
        public ActionResult Index()
        {
            var data = u.Gets();
            return View(data);
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var ha = u.Gets();
            var data = u.Gets().Select(u => new UserViewModel
            {
                UserId = u.UserId,
                Name = u.FirstName + " "+ u.LastName,
                Email = u.Email,
                Phone = u.Phone,
                UserName = u.UserName,
                Password = u.Password,
                Created = u.Created,
                Updated = u.Created,
                Rate = u.Rate,
                Status = u.Status
            });
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        // create a user accout
        [HttpPost]
        public ActionResult Create(Users user)
        {
            int num = u.Gets().Count();
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

        // return view of user's all infomation 
        [HttpGet]
        public ActionResult Details(string id)
        {
            var dtl = u.Get(id);
            return View(dtl);
        }

        // get user detail by id
        [HttpGet]
        public ActionResult Update(string id)
        {
            var data = u.Get(id);
            return Json(data,JsonRequestBehavior.AllowGet);
        }

        // edit user's info with new info
        [HttpPost]
        public ActionResult Update(Users user)
        {
            user.Updated = DateTime.Now;
            if (u.Update(user))
                return Json(new { CodeStatus = 200, message = "Update complete!" });
            return Json(new { CodeStatus = 200, message = "Update faild!" });
        }

        // ban user to login into website
        [HttpGet]
        public ActionResult BanUser(string id)
        {
            string msg = "User have been banned!";
            var target = u.Get(id);
            target.Status = false;
            u.Update(target);
            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        // Delete a Account and every items , biglogs , orders
        [HttpDelete]
        public ActionResult Delete(string id)
        {
            string msg;
            var items = item.Gets().Where(i => i.UserId == id);
            var bibs = bl.Gets().Where(i => i.UserId == id);
            var ordes = ods.Gets().Where(i => i.UserId == id);


            foreach (var i in items)
            {
                item.Remove(i);
            }
            foreach (var b in bibs)
            {
                bl.Remove(b);
            }
            foreach (var o in ordes)
            {
                ods.Remove(o);
            }

            if (u.Remove(id))
                msg = "Deleted";
            msg = "Error";

            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        // Show up all order of  user
        [HttpGet]
        public ActionResult GetOrders(string id)
        {
            var data = ods.Gets(x => x.UserId.Equals(id)).OrderBy(x => x.Created);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        // Show up all item of  user that are selling
        [HttpGet]
        public ActionResult GetItems(string id)
        {
            var data = item.Gets(x => x.BidStatus == true);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        // Show up all rating user have
        [HttpGet]
        public ActionResult GetRate(string id)
        {
            var data = rate.Gets(x => x.ToId.Equals(id)).Select(x => new RateViewModel
            {
                FromUser = x.FromUser.FirstName + " " + x.FromUser.LastName,
                ToUser = x.ToUser.FirstName + " " + x.ToUser.LastName,
                Comment = x.Comment,
                Rate = x.Rate,
                Created = x.Created
            }).OrderBy(x => x.Created);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}