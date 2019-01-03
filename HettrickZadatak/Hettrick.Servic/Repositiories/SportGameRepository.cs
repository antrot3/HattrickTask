using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hettrick.Servic.Models.Entities;


namespace Hettrick.Servic.Repositiories
{
    public interface ISportGameRepository
    {
        SportGame GetSportGameById(int Id);
    }

    public class SportGameRepository : ISportGameRepository
    {
        private readonly Hettrick.Servic.Models.HettrickContext _context;
        public SportGameRepository()
        {
            _context = new Models.HettrickContext();
        }

        public SportGame GetSportGameById(int Id)
        {
            return _context.SportGames.Where(x => x.Id == Id).First();
        }
    }
}
