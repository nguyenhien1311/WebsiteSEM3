using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBML.Repositories;
using WebDAL.DataModels;

namespace WebOnlineAuction.Controllers
{
    public class ItemsController : Controller
    {
        IRepository<Items> items;
        public ItemsController()
        {
            items = new Repository<Items>();
        }
        // GET: Items
        public ActionResult Index()
        {
            var data = items.Gets();
            return View(data);
        }
    }
}