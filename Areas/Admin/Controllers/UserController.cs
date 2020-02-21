using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;
using WebApplication1.Commons;

namespace WebApplication1.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var EncryptedMd5 = Encryptor.MD5Hash(user.Password);
                user.Password = EncryptedMd5;
                long id = dao.Insert(user);
                if(id> 0)
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Không thêm được User!");
                }
            }
            return View("Index");
            

        }
    }
}