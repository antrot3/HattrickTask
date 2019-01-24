using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hattrick.Service.Models.Entities;


namespace Hattrick.Service.Repositiories
{
    public interface ISportCategoryRepository
    {
        SportCategory GetSportCategoryById(int Id);
        IEnumerable<SportCategory> GetAllSportCategory();
    }

    public class SportCategoryRepository : ISportCategoryRepository
    {
        private readonly Hattrick.Service.Models.HattrickContext _context;
        public SportCategoryRepository()
        {
            _context = new Models.HattrickContext();
        }

        public SportCategory GetSportCategoryById(int Id)
        {
            return _context.sportCategories.Where(x => x.Id == Id).First();
        }
        public IEnumerable<SportCategory> GetAllSportCategory()
        {
            return _context.sportCategories;
        }
    }
}
