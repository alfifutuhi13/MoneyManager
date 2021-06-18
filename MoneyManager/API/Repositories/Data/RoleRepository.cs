using API.Context;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Data
{
    public class RoleRepository : GeneralRepository<Role, MyContext, int>
    {
        private readonly MyContext context;
        public RoleRepository(MyContext context) : base(context)
        {
            this.context = context;
        }
    }
}
