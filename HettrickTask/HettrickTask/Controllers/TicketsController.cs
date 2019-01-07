using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Hattrick.Service.Models;
using Hattrick.Service.Models.Entities;

using Hattrick.Service.Repositiories;
using Newtonsoft.Json.Linq;

namespace HettrickZadatak.Controllers
{
    public class TicketsController : Controller
    {
        private HattrickContext db = new HattrickContext();
        private readonly ITicketRepository _ticketRepository;
        private readonly ITicketToGameRepository _ticketToGameRepository;

        public TicketsController()
        {
            _ticketRepository = new TicketRepository();
            _ticketToGameRepository = new TicketToGameRepository();
        }
        public ActionResult Create(string data)
        {
            var _context = new HattrickContext();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var obj = serializer.Deserialize<Dictionary<string, object>>(data);
            var profile = _context.Profiles.First();
            if (profile.AccountBallance < double.Parse(obj["betValue"].ToString()))
                throw new System.ArgumentException("Not Enough money to bet");
            else
            {
                profile.AccountBallance -= double.Parse(obj["betValue"].ToString());
            }
            _context.SaveChanges();
            var ticket = _ticketRepository.CreateTicket(double.Parse(obj["betValue"].ToString()), double.Parse(obj["koeficientValue"].ToString()), double.Parse(obj["expectedPayout"].ToString()));
            foreach (var test in (dynamic)obj["listOfSelectedPairs"])
            {
                _ticketToGameRepository.CreateTicketToGame(int.Parse(test["GameID"]), ticket.Id, double.Parse(test["BetKoeficent"]), test["SelectedBet"]);
            }


            return Redirect("/Tickets/Index");
        }


        // GET: Tickets
        public ActionResult Index()
        {
            var tickets = db.Tickets.Include(t => t.Profile);
            IEnumerable<Hattrick.Service.Models.Entities.TicketToGame> tickesToGame = db.TicketToGames.ToList();
            ViewBag.ticketsToGame = tickesToGame;
            return View(tickets.ToList());
        }

        public ActionResult GetResoult(string resoult, int id,double addToAccount)
        {
            var profile = db.Profiles.First();;
            if (resoult == "Victory")
                profile.AccountBallance += addToAccount;
            var ticket = db.Tickets.Find(id);
            db.Tickets.Remove(ticket);
            db.SaveChanges();
            return Redirect("Tickets/Index");
        }
      
    }
}
