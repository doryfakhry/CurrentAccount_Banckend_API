using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrentAccount.Data
{
    public class User
    {
        
        public int Id { get; set; }
        public String Name { get; set; }
        public String SurName { get; set; }
        public virtual IList<Account> AccountList { get; set; }

        
    }
}
