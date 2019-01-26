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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Hattrick.Service.Controllers
{
    public class TicketsController : Controller
    {
        private HattrickContext _context = new HattrickContext();
        private readonly ITicketToGameRepository _ticketToGameRepository;

        public TicketsController()
        {
            _ticketToGameRepository = new TicketToGameRepository();
        }
        public ActionResult Create(string data)
        {
            var serializer = new JavaScriptSerializer();
            var obj = serializer.Deserialize<Dictionary<string, object>>(data);

            var profile = _context.Profiles.First();
            if (profile.AccountBalance < double.Parse(obj["betValue"].ToString()))
                throw new Exception("Not Enough money to bet");
            profile.AccountBalance -= double.Parse(obj["betValue"].ToString());
            _context.SaveChanges();
            var ticketReository = new TicketRepository();
            var ticket = ticketReository.CreateTicket(double.Parse(obj["betValue"].ToString()), double.Parse(obj["koeficientValue"].ToString()), double.Parse(obj["expectedPayout"].ToString()));
            var ticketItem = JsonConvert.DeserializeObject<TicketItem>(data);
            foreach (var item in ticketItem.listOfSelectedPairs)
            {
                try
                {
                    _ticketToGameRepository.CreateTicketToGame(int.Parse(item.GameID), ticket.Id, double.Parse(item.BetKoeficent), item.SelectedBet);
                }
                catch (Exception ex)
                {
                    throw new Exception("Cannot add Pair to ticket "+ex.ToString());
                }
            }

            return Redirect("/Tickets/Index");
        }

        public class TicketItem
        {
            public string betValue { get; set; }
            public string koeficientValue { get; set; }
            public string expectedPayout { get; set; }
            public List<ListItem> listOfSelectedPairs { get; set; }
        }
        public class ListItem
        {
            public string SelectedBet { get; set; }
            public string GameID { get; set; }
            public string BetKoeficent { get; set; }
            public string Team1 { get; set; }
            public string Team2 { get; set; }
            public string SpecialOffer { get; set; }
            public string SpecialOfferFactor { get; set; }
        }

        // GET: Tickets
        public ActionResult Index()
        {
            var tickets = _context.Tickets.Include(t => t.Profile);
            IEnumerable<Hattrick.Service.Models.Entities.TicketToGame> tickesToGame = _context.TicketToGames.ToList();
            ViewBag.ticketsToGame = tickesToGame;
            return View(tickets.ToList());
        }

        public ActionResult GetResult(string resoult, int id, double addToAccount)
        {
            var profile = _context.Profiles.First(); ;
            if (resoult == "Victory")
                profile.AccountBalance += addToAccount;
            var ticket = _context.Tickets.Find(id);
            _context.Tickets.Remove(ticket);
            _context.SaveChanges();
            return Redirect("~/Tickets/Index");
        }

    }
}
