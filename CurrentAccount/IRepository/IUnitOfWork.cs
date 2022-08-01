using CurrentAccount.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//whenever we have a new data model,just add it here and in UnitOfWork
namespace CurrentAccount.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Account> Accounts { get; }
        IGenericRepository<Transaction> Transactions { get; }
        IGenericRepository<User> Users { get; }
        //IGenericRepository<CreateAccount> Account { get; }
        Task Save();
    }
}
