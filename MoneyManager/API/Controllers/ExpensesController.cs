﻿using API.Base;
using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : BaseController<Expense, ExpenseRepository, int>
    {
        private readonly ExpenseRepository expenseRepository;
        public ExpensesController(ExpenseRepository expenseRepository) : base(expenseRepository)
        {
            this.expenseRepository = expenseRepository;
        }
    }
}
