using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using WebBML.Repositories;
using WebDAL.DataModels;
using WebDML.ViewModels;

namespace WebOnlineAuction.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        IRepository<Category> c;
        IRepository<Items> i;

        public CategoryController()
        {
            c = new Repository<Category>();
            i = new Repository<Items>();
        }

        // GET: Admin/Category
        public ActionResult Index(int? page)
        {
            Administrator check = Session["admin"] as Administrator;
            if (check != null)
            {
                int pageNum = page ?? 1;
                int pageSize = 8;
                var data = c.Gets();
                var pdata = data.OrderBy(x => x.CategoryId).ToPagedList(pageNum, pageSize);
                ViewBag.cat = pdata;
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }


        // get category list
        [HttpGet]
        public ActionResult GetAll() {
            var data = c.Gets().Select(c => new CategoryViewModel
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName,
                Description = c.Description
            });
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        //create a category 
        [HttpPost]
        public ActionResult Create(Category cat)
        {
            if (c.Create(cat))
                return Json(new { CodeStatus = 200, message = "Create category complete!" });
            return Json(new { CodeStatus = 200, message = "Create category faild!" });
        }

        // get category by id
        [HttpGet]
        public ActionResult Update(string id)
        {
            var data = c.Get(id);
            return Json(data,JsonRequestBehavior.AllowGet);
        }
        // edit category's info with new info
        [HttpPost]
        public ActionResult Update(Category cat)
        {
            if (c.Update(cat))
                return Json(new { CodeStatus = 200, message = "Update complete!" });
            return Json(new { CodeStatus = 200, message = "Update fail!" });
        }

        // delete a category 
        [HttpGet]
        public ActionResult Delete(string id)
        {
            var dd = c.Get(id);
            c.Remove(id);
            return Json(new
            {
                message = "Delete complete!",
                status = true
            });
        }

        // merge 2 category anh change all categoryid of the merged items 
        [HttpPost]
        public ActionResult Merge(string fromId , string toId) {
            var items = i.Gets().Where(i => i.CategoryId == fromId);
            foreach (var item in items)
            {
                item.CategoryId = toId;
            }
            if (c.Remove(fromId))
                return Json(new { status = true, message = "Merge 2 category completed!" });
            return Json(new { status = false, message = "Merge category failed!" });
        }
    }
}