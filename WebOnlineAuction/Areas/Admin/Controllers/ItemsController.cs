using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBML.Repositories;
using WebDAL.DataModels;
using WebDML.ViewModels;

namespace WebOnlineAuction.Areas.Admin.Controllers
{
    public class ItemsController : Controller
    {
        IRepository<Items> items;
        IRepository<BidLog> log;
        public ItemsController()
        {
            items = new Repository<Items>();
            log = new Repository<BidLog>();
        }

        // GET: Admin/Items
        public ActionResult Index(bool? sort)
        {
            Administrator check = Session["admin"] as Administrator;
            if (check != null)
            {
                var sorted = sort ?? false;
                var data = items.Gets(x => x.BidStatus == true).OrderBy(c => c.BidStartDate);
                if (sorted)
                {
                    ViewBag.sort = sort;
                    data = data.OrderByDescending(xx => xx.BidIncrement);
                }
                return View(data);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        // get Item list are active/aucting
        [HttpGet]
        public ActionResult GetAll(bool? sort)
        {
            var sorted = sort ?? false;
            var data = items.Gets(x=>x.BidStatus == true).Select(c => new ItemViewModel
            {
                ItemId = c.ItemId,
                ItemTitle = c.ItemTitle,
                CategorynName = c.Category.CategoryName,
                UserName = c.Users.UserName,
                ItemImage = c.ItemImage,
                BidStartDate = c.BidStartDate,
                BidEndDate = c.BidEndDate.ToLocalTime(),
                BidIncrement = c.BidIncrement,
                MinimumBid = c.MinimumBid,
                BidStatus = c.BidStatus
            }).OrderBy(c => c.BidStartDate);
            if (sorted)
            {
                data = data.OrderByDescending(xx => xx.BidIncrement);
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        // return view of user's all infomation 
        [HttpGet]
        public ActionResult Details(string id)
        {
            var dtl = items.Get(id);
            return View(dtl);
        }

        [HttpGet]
        public ActionResult GetInfo(string id)
        {
            var dtl = items.Get(id);
            ItemViewModel v = new ItemViewModel();
            v.ItemId = dtl.ItemId;
            return Json(v, JsonRequestBehavior.AllowGet);
        }

        // rediect to view item  bid log 
        public ActionResult ViewLog(string id) {
            var bidlog = log.Gets(x => x.ItemId.Equals(id)).OrderBy(x => x.BidPrice);
            return View(bidlog);
        }
    }
}