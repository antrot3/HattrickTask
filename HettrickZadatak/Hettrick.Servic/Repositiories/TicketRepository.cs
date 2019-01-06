using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hattrick.Servic.Models.Entities;

namespace Hattrick.Servic.Repositiories
{
    public interface ITicketRepository
    {
        Ticket GetTicketById(int Id);
    }

    public class TicketRepository : ITicketRepository
    {
        private readonly Hattrick.Servic.Models.HattrickContext _context;
        public TicketRepository()
        {
            _context = new Models.HattrickContext();
        }

        public Ticket GetTicketById(int Id)
        {
            return _context.Tickets.Where(x => x.Id == Id).First();
        }
    }
}
