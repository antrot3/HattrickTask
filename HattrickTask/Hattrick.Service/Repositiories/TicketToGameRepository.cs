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
        TicketToGame CreateTicketToGame(int SportGameId, int ticketId, double PairCoefficient, string selectedValue);
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
            return _context.TicketToGames.First(x => x.Id == Id);
        }
        public TicketToGame CreateTicketToGame(int SportGameId, int ticketId, double PairCoefficient, string selectedValue)
        {
            var ticketToGame = new TicketToGame();
            ticketToGame.SportGameId = SportGameId;
            ticketToGame.SelectedValue = selectedValue;
            ticketToGame.PairCoefficient = PairCoefficient;
            ticketToGame.TicketId = ticketId;
            _context.TicketToGames.Add(ticketToGame);
            _context.SaveChanges();
            return _context.TicketToGames.ToList().Last();

        }
    }
}
