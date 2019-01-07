using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hattrick.Service.Models.Entities;


namespace Hattrick.Service.Repositiories
{
    public interface ISportGameRepository
    {
        SportGame GetSportGameById(int Id);
        IEnumerable<SportGame> GetAllSportGames();
    }

    public class SportGameRepository : ISportGameRepository
    {
        private readonly Hattrick.Service.Models.HattrickContext _context;
        public SportGameRepository()
        {
            _context = new Models.HattrickContext();
        }

        public SportGame GetSportGameById(int Id)
        {
            return _context.SportGames.Where(x => x.Id == Id).First();
        }
        public IEnumerable<SportGame> GetAllSportGames()
        {

            return _context.SportGames;
        }
    }
}
