using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hettrick.Servic.Models.Entities;


namespace Hettrick.Servic.Repositiories
{
    public interface ISportCategoryRepository
    {
        SportCategory GetSportCategoryById(int Id);
        IEnumerable<SportCategory> GetAllSportCategory();
    }

    public class SportCategoryRepository : ISportCategoryRepository
    {
        private readonly Hettrick.Servic.Models.HettrickContext _context;
        public SportCategoryRepository()
        {
            _context = new Models.HettrickContext();
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
