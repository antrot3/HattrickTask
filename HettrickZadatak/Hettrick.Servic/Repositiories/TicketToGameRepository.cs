using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hettrick.Servic.Models.Entities;


namespace Hettrick.Servic.Repositiories
{
    public interface ITicketToGameRepository
    {
        TicketToGame GetTicketToGameById(int Id);
    }

    public class TicketToGameRepository : ITicketToGameRepository
    {
        private readonly Hettrick.Servic.Models.HettrickContext _context;
        public TicketToGameRepository()
        {
            _context = new Models.HettrickContext();
        }

        public TicketToGame GetTicketToGameById(int Id)
        {
            return _context.TicketToGames.Where(x => x.Id == Id).First();
        }
    }
}
