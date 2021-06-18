using API.Context;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Data
{
    public class TransactionExpenseRepository : GeneralRepository<TransactionExpense, MyContext, int>
    {
        private readonly MyContext context;
        public TransactionExpenseRepository(MyContext context) : base(context)
        {
            this.context = context;
        }
    }
}
