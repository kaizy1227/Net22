using Model;
using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetCuoiKy.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        public ActionResult Index(string searchString, int page = 1, int pagesize = 10)
        {
            var product = new ProductDao();
            var model = product.listAllPaging(searchString, page, pagesize);
            return View(model);
        }
        

       

        public ActionResult Delete (int id)
        {
            new ProductDao().Delete(id);
            return RedirectToAction("Index");
        }
        
        
    }
}