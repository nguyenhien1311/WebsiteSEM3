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
        public ActionResult Index()
        {
            return View();
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
            return Json(new { CodeStatus = 200, Data = c.Get(id) });
        }
        // edit category's info with new info
        [HttpPost]
        public ActionResult Update(Category cat)
        {
            if (c.Update(cat))
                return Json(new { CodeStatus = 200, message = "Update complete!" });
            return Json(new { CodeStatus = 200, message = "Update faild!" });
        }

        // delete a category 
        [HttpDelete]
        public ActionResult Delete(string id)
        {
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
            c.Remove(fromId);
            return Json(new { status = true, message = "Merge 2 category completed!" });
        }
    }
}