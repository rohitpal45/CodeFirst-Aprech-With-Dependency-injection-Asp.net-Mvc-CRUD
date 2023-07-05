using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MenuMasterInterface.InterFaces;
using MenuMasterInterface.Models;
using MenuMasterInterface.Repository;

namespace MenuMasterInterface.Controllers
{
    public class MenuMastersController : Controller
    {
        private readonly IMenu _iMenu;
        public MenuMastersController(IMenu menu)
        {
            _iMenu = menu;
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View(_iMenu.GetAllMenu());
        }
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuMaster menuMaster = _iMenu.GetMenuById(id);
            if (menuMaster == null)
            {
                return HttpNotFound();
            }
            return View(menuMaster);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MenuId,ControllerName,ActionMethod,MenuName,Status,CreateDate,IsCache,UserId")] MenuMaster menuMaster)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _iMenu.AddMenu(menuMaster);
                    return RedirectToAction("Index");
                }

                return View(menuMaster);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                MenuMaster menuMaster = _iMenu.GetMenuById(id);
                if (menuMaster == null)
                {
                    return HttpNotFound();
                }
                return View(menuMaster);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MenuId,ControllerName,ActionMethod,MenuName,Status,CreateDate,IsCache,UserId")] MenuMaster menuMaster)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    menuMaster.UserId = Convert.ToInt32(Session["UserID"]);
                    _iMenu.UpdateMenu(menuMaster);
                    return RedirectToAction("Index");
                }
                return View(menuMaster);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                MenuMaster menuMaster = _iMenu.GetMenuById(id);
                if (menuMaster == null)
                {
                    return HttpNotFound();
                }
                return View(menuMaster);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _iMenu.DeleteMenu(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
