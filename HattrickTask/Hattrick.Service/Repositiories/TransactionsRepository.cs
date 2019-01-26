using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hattrick.Service.Models.Entities;

namespace Hattrick.Service.Repositiories
{
    public interface ITransactionsRepository
    {
        Transactions GetTransactionsById(int Id);
    }

    public class TransactionsRepository : ITransactionsRepository
    {
        private readonly Hattrick.Service.Models.HattrickContext _context;
        public TransactionsRepository()
        {
            _context = new Models.HattrickContext();
        }

        public Transactions GetTransactionsById(int Id)
        {
            return _context.Transactions.First(x => x.Id == Id);
        }
    }
}
