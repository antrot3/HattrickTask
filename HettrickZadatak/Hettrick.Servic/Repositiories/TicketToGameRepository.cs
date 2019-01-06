using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hattrick.Servic.Models.Entities;


namespace Hattrick.Servic.Repositiories
{
    public interface ITicketToGameRepository
    {
        TicketToGame GetTicketToGameById(int Id);
    }

    public class TicketToGameRepository : ITicketToGameRepository
    {
        private readonly Hattrick.Servic.Models.HattrickContext _context;
        public TicketToGameRepository()
        {
            _context = new Models.HattrickContext();
        }

        public TicketToGame GetTicketToGameById(int Id)
        {
            return _context.TicketToGames.Where(x => x.Id == Id).First();
        }
    }
}
