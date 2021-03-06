﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hattrick.Service.Models;
using Hattrick.Service.Models.Entities;
using Hattrick.Service.Repositiories;

namespace HattrickTask.Controllers
{
    public class SportGamesController : Controller
    {
        private HattrickContext db = new HattrickContext();

        private readonly ISportCategoryRepository _sportCategoryRepository;

        public SportGamesController()
        {
            _sportCategoryRepository = new SportCategoryRepository();

        }
        // GET: SportGames
        public ActionResult Index()
        {
            var sportGames = db.SportGames.Include(s => s.SportCategory);
            return View(sportGames.ToList());
        }

        // GET: SportGames/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var sportGame = db.SportGames.Find(id);
            if (sportGame == null)
            {
                return HttpNotFound();
            }
            return View(sportGame);
        }

        // GET: SportGames/Create
        public ActionResult Create()
        {

            ViewBag.CategoryId = new SelectList(db.sportCategories, "Id", "CategoryName");
            IEnumerable<SportCategory> sportCategorys= _sportCategoryRepository.GetAllSportCategory();
            ViewBag.SportCategorys = sportCategorys.ToList();
            return View();
        }

        // POST: SportGames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CategoryId,Team1,Team2,Value1,Value2,Value1X,Value2X,Value12,ValueX,TopOffer,TopOfferFactor,GameTime")] SportGame sportGame)
        {
            if (ModelState.IsValid)
            {
                db.SportGames.Add(sportGame);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.sportCategories, "Id", "CategoryName", sportGame.CategoryId);
            return View(sportGame);
        }

        // GET: SportGames/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var sportGame = db.SportGames.Find(id);
            if (sportGame == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.sportCategories, "Id", "CategoryName", sportGame.CategoryId);
            return View(sportGame);
        }

        // POST: SportGames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CategoryId,Team1,Team2,Value1,Value2,Value1X,Value2X,Value12,ValueX,TopOffer,TopOfferFactor,GameTime")] SportGame sportGame)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sportGame).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.sportCategories, "Id", "CategoryName", sportGame.CategoryId);
            return View(sportGame);
        }

        // GET: SportGames/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SportGame sportGame = db.SportGames.Find(id);
            if (sportGame == null)
            {
                return HttpNotFound();
            }
            return View(sportGame);
        }

        // POST: SportGames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var sportGame = db.SportGames.Find(id);
            db.SportGames.Remove(sportGame);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
