using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hattrick.Service.Models.Entities;

namespace Hattrick.Service.Repositiories
{
    public interface ITicketRepository
    {
        Ticket GetTicketById(int Id);
        Ticket CreateTicket(double payment, double totalCoeficient, double expectedPayout);
    }

    public class TicketRepository : ITicketRepository
    {
        private readonly Hattrick.Service.Models.HattrickContext _context;
        public TicketRepository()
        {
            _context = new Models.HattrickContext();
        }

        public Ticket GetTicketById(int Id)
        {
            return _context.Tickets.Where(x => x.Id == Id).First();
        }
        public Ticket CreateTicket(double payment, double totalCoeficient,double expectedPayout)
        {
            var profile = _context.Profiles.First();
            var ticket = new Ticket();
            ticket.Payment = payment;
            ticket.ProfileId = profile.Id;
            ticket.CurrentlyActive = false;
            ticket.TotalCoeficient = totalCoeficient;
            ticket.ExpectedPayout = expectedPayout;
            _context.Tickets.Add(ticket);
            _context.SaveChanges();
            return _context.Tickets.ToList().Last();
        }
    }
}
