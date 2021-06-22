using NetCuoiKy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.Dao;
using NetCuoiKy.Common;

namespace NetCuoiKy.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.LoginAdmin(model.Username, Encryptor.MD5Hash(model.Password));
                if (result==1)
                {
                    var user = dao.GetById(model.Username);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.ID;
                    Session.Add(CommonConstant.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại.");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Bạn không có quyền truy cập.");
                }
               
                else
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng");
                }
            }
            return View("Index");
        }
    }
}