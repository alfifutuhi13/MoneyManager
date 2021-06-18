using API.Context;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Data
{
    public class ExpenseRepository : GeneralRepository<Expense, MyContext, int>
    {
        private readonly MyContext context;

        public ExpenseRepository(MyContext context) : base(context)
        {
            this.context = context;
        }
    }
}
