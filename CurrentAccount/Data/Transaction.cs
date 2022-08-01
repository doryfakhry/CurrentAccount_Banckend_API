using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CurrentAccount.Data
{
    public class Transaction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //[Required]
        public DateTime TransactionDate { get; set; }
        public double Amount { get; set; }
       
        [ForeignKey(nameof(Account))]       
        public int AccountId { get; set; }
        public Account account { get; set; }



    }
}
