using API.Context;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Data
{
    public class IncomeRepository : GeneralRepository<Income, MyContext, int>
    {
        private readonly MyContext context;
        public IncomeRepository(MyContext context) : base(context)
        {
            this.context = context;
        }
    }
}
