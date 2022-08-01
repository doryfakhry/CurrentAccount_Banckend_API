using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace CurrentAccount.Data
{
    public class Account
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
       // public int customerID { get; set; }
        public Double initialcredit { get; set; }
        public virtual IList<Transaction> TransactionList { get; set; }

        [ForeignKey(nameof(User))]       
        public int UserId { get; set; }
        public User user { get; set; }



    }
}
