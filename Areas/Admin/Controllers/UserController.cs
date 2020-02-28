using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;
using WebApplication1.Commons;
using PagedList;

namespace WebApplication1.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new UserDao();
            var model = dao.ListAll(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        public ActionResult Edit(int ID)
        {
            var user = new UserDao().ViewDetail(ID);
            return View(user);
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
                if (id > 0)
                {
                    SetAlert("Thêm user thành công!", "alert-success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm user thất bại");
                }
            }
            return View("Index");
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                //var EncryptedMd5 = Encryptor.MD5Hash(user.Password);
                //user.Password = EncryptedMd5;
                var result = dao.Update(user);
                if (result)
                {
                    SetAlert("Cập nhật user thành công!", "alert-success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "cập nhật không thành công!");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int ID)
        {
            new UserDao().Delete(ID);
            return View();
        }
        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var dao = new UserDao().ChangeStatus(id);

            return Json(new
            {
                status = dao
            }) ;
        }
    }
}