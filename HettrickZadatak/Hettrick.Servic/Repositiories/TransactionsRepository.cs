using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hettrick.Servic.Models.Entities;

namespace Hettrick.Servic.Repositiories
{
    public interface ITransactionsRepository
    {
        Transactions GetTransactionsById(int Id);
    }

    public class TransactionsRepository : ITransactionsRepository
    {
        private readonly Hettrick.Servic.Models.HettrickContext _context;
        public TransactionsRepository()
        {
            _context = new Models.HettrickContext();
        }

        public Transactions GetTransactionsById(int Id)
        {
            return _context.Transactions.Where(x => x.Id == Id).First();
        }
    }
}
