using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetCuoiKy.Controllers
{
    public class ProductController : Controller
    {
        // GET: Productdddđđđssssss
        
        public PartialViewResult ProductCategory()
        {
            var model = new ProductCategoryDao().ListAll();
            return PartialView(model);
        }
        public ActionResult Category(long cateid,int page=1,int pageSize=12)
        {
            var category = new CategoryDao().ViewDetail(cateid);
            ViewBag.Category = category;
            int totalRecord = 0;
            var model = new ProductDao().ListByCategoryId(cateid, ref totalRecord, page, pageSize);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling(((double)totalRecord / (double)pageSize));
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page + 1;
            return View(model);
        }

        public ActionResult Detail( long id)
        {
            var product = new ProductDao().ViewDetail(id);
            ViewBag.Category = new ProductCategoryDao().ViewDetail(product.CategoryID.Value);
            ViewBag.ReletedProducts = new ProductDao().ListRelatedProducts(id);
            
            return View(product);
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}