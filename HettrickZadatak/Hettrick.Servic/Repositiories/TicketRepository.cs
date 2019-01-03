using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hettrick.Servic.Models.Entities;

namespace Hettrick.Servic.Repositiories
{
    public interface ITicketRepository
    {
        Ticket GetTicketById(int Id);
    }

    public class TicketRepository : ITicketRepository
    {
        private readonly Hettrick.Servic.Models.HettrickContext _context;
        public TicketRepository()
        {
            _context = new Models.HettrickContext();
        }

        public Ticket GetTicketById(int Id)
        {
            return _context.Tickets.Where(x => x.Id == Id).First();
        }
    }
}
