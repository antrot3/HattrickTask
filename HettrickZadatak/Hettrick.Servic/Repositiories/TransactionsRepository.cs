using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hattrick.Servic.Models.Entities;

namespace Hattrick.Servic.Repositiories
{
    public interface ITransactionsRepository
    {
        Transactions GetTransactionsById(int Id);
    }

    public class TransactionsRepository : ITransactionsRepository
    {
        private readonly Hattrick.Servic.Models.HattrickContext _context;
        public TransactionsRepository()
        {
            _context = new Models.HattrickContext();
        }

        public Transactions GetTransactionsById(int Id)
        {
            return _context.Transactions.Where(x => x.Id == Id).First();
        }
    }
}
