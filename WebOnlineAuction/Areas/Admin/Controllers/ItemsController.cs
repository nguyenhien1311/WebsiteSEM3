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
        public ActionResult Index()
        {
            return View();
        }

        // get Item list
        [HttpGet]
        public ActionResult GetAll()
        {
            var data = items.Gets().Where(c => c.BidStatus == true).Select(c => new ItemViewModel
            {
                ItemId = c.ItemId,
                ItemTitle = c.ItemTitle,
                CategorynName = c.Category.CategoryName,
                UserName = c.Users.UserName,
                ItemImage = c.ItemImage,
                BidStartDate = c.BidStartDate,
                BidEndDate = c.BidEndDate,
                BidIncrement = c.BidIncrement,
                MinimumBid = c.MinimumBid,
                BidStatus = c.BidStatus
            }).OrderBy(c => c.BidStartDate);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        // return view of user's all infomation 
        [HttpGet]
        public ActionResult Details(string id)
        {
            var dtl = items.Get(id);
            ItemViewModel tg = new ItemViewModel();
            tg.ItemId = dtl.ItemId;
            tg.ItemTitle = dtl.ItemTitle;
            tg.CategorynName = dtl.Category.CategoryName;
            tg.UserName = dtl.Users.UserName;
            tg.ItemImage = dtl.ItemImage;
            tg.BidStartDate = dtl.BidStartDate;
            tg.BidEndDate = dtl.BidEndDate;
            tg.BidIncrement = dtl.BidIncrement;
            tg.MinimumBid = dtl.MinimumBid;
            tg.BidStatus = dtl.BidStatus;
            tg.ItemDescription = dtl.ItemDescription;
            return View(tg);
        }

        // rediect to view item  bid log 
        public ActionResult ViewLog(string id) {
            var bidlog = log.Gets(x => x.ItemId.Equals(id)).OrderBy(x => x.BidPrice);
            return View(bidlog);
        }
    }
}