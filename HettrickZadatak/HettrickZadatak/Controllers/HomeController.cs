﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hettrick.Servic.Models;
using Hettrick.Servic.Repositiories;
using AutoMapper;

namespace HettrickZadatak.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISportGameRepository _sportGameRepository;
        private readonly ISportCategoryRepository _sportCategoryRepository;
        private readonly IProfileRepository _profileRepository;


        public HomeController()
        {
            _sportGameRepository = new SportGameRepository();
            _sportCategoryRepository = new SportCategoryRepository();
            _profileRepository = new ProfileRepository();
        }
        public ActionResult Index()
        {
            var _context = new HettrickContext();
            
            IEnumerable<Hettrick.Servic.Models.Entities.SportCategory> sportCategorys = _sportCategoryRepository.GetAllSportCategory().ToList();
            ViewBag.Categorys = sportCategorys;
            Hettrick.Servic.Models.Entities.Profile profile = _profileRepository.GetFirstUser();
            ViewBag.Profile = profile;
            IEnumerable<Hettrick.Servic.Models.Entities.SportGame> sportGames = _sportGameRepository.GetAllSportGames().ToList();
            return View(sportGames);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}