using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Areas.Admin.Controllers
{
    public class ContentController : BaseController
    {
        // GET: Admin/Content
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new ContentDao();
            var model = dao.ListAll(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        [HttpGet]
        public ActionResult Edit(long id)
        {
            var dao = new ContentDao();
            var content = dao.getByid(id);
            SetViewBag(content.CategoryID);
            return View(content);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Content model)
        {
            if (ModelState.IsValid)
            {
                var dao = new ContentDao();
                var content = dao.Edit(model);
                if (content)
                {
                    SetAlert("Bạn đã edit thành công", "alert-success");
                    return RedirectToAction("Index", "Content");

                }
                else
                {
                    ModelState.AddModelError("", "cập nhật thất bại");
                }

            }
            SetViewBag(model.CategoryID);
            return View("Index");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Content model)
        {
            if (ModelState.IsValid)
            {
                var db = new ContentDao();
                long content = db.Create(model);
                if (content > 0)
                {
                    SetAlert("Bạn đã thêm mới content thành công", "alert-success");
                    return RedirectToAction("Index", "Content");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm mới thất bại");
                }
            }
            SetViewBag();
            return View();
        }
        [HttpDelete]
        [ValidateInput(false)]  
        public ActionResult Delete(int id)
        {
            var dao = new ContentDao().Delete(id);
            return View();
        }
        public void SetViewBag(long? selectTed = null)
        {
            var dao = new CategoryDao();
            ViewBag.CategoryID = new SelectList(dao.ListAll(), "ID", "Name", selectTed);
        }
        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var dao = new ContentDao().ChangeStatus(id);

            return Json(new
            {
                status = dao
            });
        }
    }
}