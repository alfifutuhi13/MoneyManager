using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("TB_M_Transaction")]
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public User User { get; set; }
        public ICollection<TransactionIncome> TransactionIncomes { get; set; }
        public ICollection<TransactionExpense> TransactionExpenses { get; set; }
    }
}
