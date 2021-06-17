using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("TB_T_TransactionExpense")]
    public class TransactionExpense
    {
        [Key]
        public int Id { get; set; }

        public Transaction Transaction { get; set; }
        public Expense Expense { get; set; }
    }
}
