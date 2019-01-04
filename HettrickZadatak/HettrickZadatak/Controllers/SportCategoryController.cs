using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hettrick.Servic.Models;
using Hettrick.Servic.Models.Entities;

namespace HettrickZadatak.Controllers
{
    public class SportCategoryController : Controller
    {
        private HettrickContext db = new HettrickContext();

        // GET: SportCategories
        public ActionResult Index()
        {
            return View(db.SportCategorys.ToList());
        }

        // GET: SportCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SportCategory sportCategory = db.SportCategorys.Find(id);
            if (sportCategory == null)
            {
                return HttpNotFound();
            }
            return View(sportCategory);
        }

        // GET: SportCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SportCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CategoryName,Active1,Active1x,Active2x,Active12,Active2,ActiveX")] SportCategory sportCategory)
        {
            if (ModelState.IsValid)
            {
                db.SportCategorys.Add(sportCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sportCategory);
        }

        // GET: SportCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SportCategory sportCategory = db.SportCategorys.Find(id);
            if (sportCategory == null)
            {
                return HttpNotFound();
            }
            return View(sportCategory);
        }

        // POST: SportCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CategoryName,Active1,Active1x,Active2x,Active12,Active2,ActiveX")] SportCategory sportCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sportCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sportCategory);
        }

        // GET: SportCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SportCategory sportCategory = db.SportCategorys.Find(id);
            if (sportCategory == null)
            {
                return HttpNotFound();
            }
            return View(sportCategory);
        }

        // POST: SportCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SportCategory sportCategory = db.SportCategorys.Find(id);
            db.SportCategorys.Remove(sportCategory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
