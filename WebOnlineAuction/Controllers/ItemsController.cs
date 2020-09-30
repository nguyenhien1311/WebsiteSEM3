using Microsoft.Ajax.Utilities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using WebBML.Repositories;
using WebDAL.DataModels;
using WebDML.ViewModels;

namespace WebOnlineAuction.Controllers
{
    public class ItemsController : Controller
    {
        IRepository<Items> items;
        IRepository<Category> cat;
        IRepository<BidLog> log;
        public ItemsController()
        {
            items = new Repository<Items>();
            cat = new Repository<Category>();
            log = new Repository<BidLog>();
            var c = cat.Gets();
            ViewBag.cats = c;
        }
        public ActionResult Index(string key,string catid,int? page)
        {
            int pageNum = page ?? 1;
            int pageSize = 12;
            var data = items.Gets();
            foreach (var item in data)
            {
                if (item.BidEndDate == DateTime.Now)
                {
                    item.BidStatus = false;
                }
            }
            var activedata = data.Where(x => x.BidStatus == true);
            if (!String.IsNullOrEmpty(catid))
            {
                activedata = activedata.Where(x => x.CategoryId== catid);
            }
            if (!String.IsNullOrEmpty(key))
            {
                ViewBag.key = key;
                activedata = activedata.Where(x => x.ItemTitle.ToLower().Contains(key.ToLower()));
            }
            var pdata  = activedata.OrderBy(x => x.BidStartDate).ToPagedList(pageNum, pageSize);
            return View(pdata);
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            var data = items.Get(id);
            var lg = log.Gets(x => x.ItemId == id).OrderBy(x => x.BidDate);
            ViewBag.history = lg;
            return View(data);
        }

        [HttpPost]
        public ActionResult Bid(string itemid, float price) {
            var item = items.Get(itemid);
            Users u = Session["user"] as Users;
            var bids = log.Gets().FirstOrDefault(x=>x.ItemId == itemid && x.UserId == u.UserId);
            if (price > item.BidIncrement)
            {
                if (price - item.BidIncrement > item.MinimumBid)
                {
                    if (item.BidEndDate > DateTime.Now)
                    {
                        if (bids == null)
                        {
                            BidLog nw = new BidLog();
                            nw.BidDate = DateTime.Now;
                            nw.BidPrice = price;
                            nw.ItemId = itemid;
                            nw.UserId = u.UserId;
                            if (log.Create(nw))
                            {
                                item.BidIncrement = nw.BidPrice;
                                items.Update(item);
                                return Json(new { status = true, message = "Bid complete!" });
                            }
                            return Json(new { status = false, message = "transaction error!" });
                        }
                        else
                        {
                            bids.BidPrice = price;
                            bids.BidDate = DateTime.Now;
                            if (log.Update(bids))
                            {
                                item.BidIncrement = bids.BidPrice;
                                items.Update(item);
                                return Json(new { status = true, message = "Bid complete!" });
                            }
                            return Json(new { status = false, message = "transaction error!" });
                        }
                    }
                    return Json(new { status = false, message = "Auction was ended!" });
                }
                return Json(new { status = false, message = "See minimum bid please!" });
            }
            return Json(new { status = false, message = "Price have bigger than current price!" });
        }

        public ActionResult SellAnItem(){
            ViewBag.Category = new SelectList(cat.Gets(), "CategoryId","CategoryName");
            return View();
        }
        [HttpPost]
        public ActionResult SellAnItem(Items item){
            Users u = Session["user"] as Users;
            item.ItemId = AutoGenId();
            item.UserId = u.UserId;
            item.BidStartDate = DateTime.Now;
            item.BidStatus = true;
            ViewBag.Category = new SelectList(cat.Gets(), "CategoryId", "CategoryName",item.CategoryId);
            if (items.Create(item))
                return RedirectToAction("GetItemById");
            return View();
        }

        [HttpGet]
        public ActionResult GetItemById()
        {
            Users u = Session["user"] as Users;
            var data = items.Gets(x => x.UserId == u.UserId).OrderBy(x => x.BidStartDate);
            
            return View(data);
        }

        [HttpGet]
        public ActionResult ShowBuyer(string id) {
            try
            {
                var data = log.Gets(x => x.ItemId == id).OrderByDescending(x => x.BidPrice).First();
                ViewBag.highBid = data;
                return View();
            }
            catch (Exception ex)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
        }

        [HttpGet]
        public ActionResult EndAuction(string id) {
            var data = items.Get(id);
            data.BidStatus = false;
            items.Update(data);
            return RedirectToAction("GetItemById");
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            var logs = log.Gets(x => x.ItemId == id);
            foreach (var item in logs)
            {
                log.Remove(item);
            }
            if (items.Remove(id))
                 return RedirectToAction("GetItemById");
            return View();
        }

        // auto generation id typr string for items
        public string AutoGenId() {
            int num = items.Gets().Count() + 1;
            string id = "IT";
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
    }
}