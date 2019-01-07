using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hattrick.Service.Models.Entities;


namespace Hattrick.Service.Repositiories
{
    public interface ITicketToGameRepository
    {
        TicketToGame GetTicketToGameById(int Id);
        TicketToGame CreateTicketToGame(int sportGameID, int ticketId, double kvotaPara, string selectedValue);
    }

    public class TicketToGameRepository : ITicketToGameRepository
    {
        private readonly Hattrick.Service.Models.HattrickContext _context;
        public TicketToGameRepository()
        {
            _context = new Models.HattrickContext();
            
        }

        public TicketToGame GetTicketToGameById(int Id)
        {
            return _context.TicketToGames.Where(x => x.Id == Id).First();
        }
        public TicketToGame CreateTicketToGame(int sportGameID, int ticketId, double kvotaPara, string selectedValue)
        {
            var ticketToGame = new TicketToGame();
            ticketToGame.SportGameID = sportGameID;
            ticketToGame.SelectedValue = selectedValue;
            ticketToGame.KvotaPara = kvotaPara;
            ticketToGame.TicketId = ticketId;
            _context.TicketToGames.Add(ticketToGame);
            _context.SaveChanges();
            return _context.TicketToGames.ToList().Last();

        }
    }
}
