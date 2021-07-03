using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using System.Collections;

namespace NetCuoiKy.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var productDao = new ProductDao();
            ViewBag.NewProducts = productDao.ListNewProduct(4);
            ViewBag.ListFeatureProducts = productDao.ListFeatureProduct(8);
            return View();
        }

        public ActionResult Robots()
        {
            Response.ContentType = "text/plain";
            return View();
        }

        [XmlRoot("urlset", Namespace = "http://www.sitemaps.org/schemas/sitemap/0.9")]
        public class Sitemap
        {
            private ArrayList _map;

            public Sitemap()
            {
                _map = new ArrayList();
            }

            [XmlElement("url")]
            public Location[] Locations
            {
                get
                {
                    Location[] items = new Location[_map.Count];
                    _map.CopyTo(items);
                    return items;
                }
                set
                {
                    if (value == null)
                        return;
                    var items = (Location[])value;
                    _map.Clear();
                    foreach (Location item in items)
                        _map.Add(item);
                }
            }

            public int Add(Location item)
            {
                return _map.Add(item);
            }
        }

        public class Location
        {
            public enum EChangeFrequency
            {
                Always,
                Hourly,
                Daily,
                Weekly,
                Monthly,
                Yearly,
                Never
            }

            [XmlElement("loc")]
            public string Url { get; set; }

            [XmlElement("changefreq")]
            public EChangeFrequency? ChangeFrequency { get; set; }
            public bool ShouldSerializeChangeFrequency() { return ChangeFrequency.HasValue; }

            [XmlElement("lastmod")]
            public DateTime? LastModified { get; set; }
            public bool ShouldSerializeLastModified() { return LastModified.HasValue; }

            [XmlElement("priority")]
            public double? Priority { get; set; }
            public bool ShouldSerializePriority() { return Priority.HasValue; }
        }

        public class XmlResult : ActionResult
        {
            private readonly object _objectToSerialize;

            public XmlResult(object objectToSerialize)
            {
                _objectToSerialize = objectToSerialize;
            }

            public object ObjectToSerialize
            {
                get { return _objectToSerialize; }
            }

            public override void ExecuteResult(ControllerContext context)
            {
                if (_objectToSerialize != null)
                {
                    context.HttpContext.Response.Clear();
                    var xs = new XmlSerializer(_objectToSerialize.GetType());
                    context.HttpContext.Response.ContentType = "text/xml";
                    xs.Serialize(context.HttpContext.Response.Output, _objectToSerialize);
                }
            }
        }

        public ActionResult SitemapXml()
        {
            var productDao = new ProductDao();
            var sm = new Sitemap();
            sm.Add(new Location()
            {
                Url = string.Format("https://localhost:44343/"),
                LastModified = DateTime.UtcNow,
                Priority = 0.5D
            });
            sm.Add(new Location()
            {
                Url = string.Format("https://localhost:44343/about/index"),
                LastModified = DateTime.UtcNow,
                Priority = 0.5D
            });
            sm.Add(new Location()
            {
                Url = string.Format("https://localhost:44343/user/login"),
                LastModified = DateTime.UtcNow,
                Priority = 0.5D
            });
            foreach (var item in productDao.ListAllProduct())
            {
                sm.Add(new Location()
                {
                    Url = string.Format("https://localhost:44343/chi-tiet/{0}-{1}",item.MetaTilte,item.ID),
                    LastModified = DateTime.UtcNow,
                    Priority = 0.5D
                });
            }

            return new XmlResult(sm);
        }

    }
}