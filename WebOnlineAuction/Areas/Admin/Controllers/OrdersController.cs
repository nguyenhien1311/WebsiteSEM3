using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Mvc;
using WebBML.Repositories;
using WebDAL.DataModels;
using WebDML.ViewModels;

namespace WebOnlineAuction.Areas.Admin.Controllers
{
    public class OrdersController : Controller
    {

        IRepository<Orders> orders;
        public OrdersController()
        {
            orders = new Repository<Orders>();
        }
        // GET: Admin/Orders
        public ActionResult Index()
        {
            return View();
        }

        // get list order and sort by created date
        [HttpGet]
        public ActionResult GetAll() {
            var data = orders.Gets().Select(x => new OrderViewModel
            {
                OrderId =x.OrderId,
                Item = x.Items.ItemTitle,
                User =x.Users.FirstName + " " + x.Users.LastName,
                Price = x.Price,
                Created = x.Created,
                Status =x.Status
            }).OrderBy(o=>o.Created);
            return Json(data,JsonRequestBehavior.AllowGet);
        }
    }
}