using API.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace API.Repositories.Data
{
    public class TransactionRepository : GeneralRepository<Transaction, MyContext, int>
    {
        private readonly MyContext context;
        public TransactionRepository(MyContext context) : base(context)
        {
            this.context = context;
        }
    }
}
