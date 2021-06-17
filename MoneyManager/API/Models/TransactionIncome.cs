using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("TB_T_TransactionIncome")]
    public class TransactionIncome
    {
        [Key]
        public int Id { get; set; }

        public Transaction Transaction { get; set; }
        public Income Income { get; set; }
    }
}
