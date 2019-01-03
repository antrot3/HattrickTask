using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hettrick.Servic.Models.Entities;

namespace Hettrick.Servic.Repositiories
{
    public interface IProfileRepository
    {
        Profile GetProfileById(int Id);
    }

    public class ProfileRepository : IProfileRepository
    {
        private readonly Hettrick.Servic.Models.HettrickContext _context;
        public ProfileRepository()
        {
            _context = new Models.HettrickContext();
        }

        public Profile GetProfileById(int Id)
        {
            return _context.Profiles.Where(x => x.Id == Id).First();
        }
    }
}
