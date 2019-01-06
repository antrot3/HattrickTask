using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hattrick.Servic.Models.Entities;


namespace Hattrick.Servic.Repositiories
{
    public interface ISportCategoryRepository
    {
        SportCategory GetSportCategoryById(int Id);
        IEnumerable<SportCategory> GetAllSportCategory();
    }

    public class SportCategoryRepository : ISportCategoryRepository
    {
        private readonly Hattrick.Servic.Models.HattrickContext _context;
        public SportCategoryRepository()
        {
            _context = new Models.HattrickContext();
        }

        public SportCategory GetSportCategoryById(int Id)
        {
            return _context.SportCategorys.Where(x => x.Id == Id).First();
        }
        public IEnumerable<SportCategory> GetAllSportCategory()
        {
            return _context.SportCategorys;
        }
    }
}
