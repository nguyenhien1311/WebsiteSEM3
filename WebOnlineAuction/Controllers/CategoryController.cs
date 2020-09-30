using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBML.Repositories;
using WebDAL.DataModels;

namespace WebOnlineAuction.Controllers
{
    public class CategoryController : Controller
    {
        IRepository<Category> cats;

        public CategoryController()
        {
            cats = new Repository<Category>();
        }
        // GET: Category
        public ActionResult GetAll()
        {
            var data = cats.Gets();
            ViewBag.cat = data;
            return View();
        }
    }
}