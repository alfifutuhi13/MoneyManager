using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [Table("TB_M_Income")]
    public class Income
    {
        [Key]
        public int Id { get; set; }
        public long Amount { get; set; }
        [DisplayFormat(DataFormatString = "{0}:dd-MM-YYYY")]
        public DateTime Date { get; set; }

        public ICollection<TransactionIncome> TransactionIncomes { get; set; }
    }
}
