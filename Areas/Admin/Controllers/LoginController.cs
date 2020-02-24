using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Areas.Admin.Models;
using WebApplication1.Commons;

namespace WebApplication1.Areas.Admin.Controllers
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
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.Password));
                if (result == 1)
                {
                    var user = dao.GetByID(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.ID;
                    Session.Add(commonconstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "User");
                }
                else if (result == 0)
                {

                    ModelState.AddModelError("", "Bạn nhập sai tên đăng nhập!");
                }
                else if (result == -1)
                {

                    ModelState.AddModelError("", "Tài khoản đã bị khóa!");
                }
                else if (result == -2)
                {

                    ModelState.AddModelError("", "Bạn đã nhập sai mật khẩu!");
                }

            }
            return View("index");

        }
    }
}