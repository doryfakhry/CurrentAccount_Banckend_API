using CurrentAccount.Data;
using CurrentAccount.IRepository;
using CurrentAccount.Models;
using CurrentAccount.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrentAccount.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IGenericRepository<Account> _accounts;
        private IGenericRepository<Transaction> _transactions;
        private IGenericRepository<User> _users;
        //private IGenericRepository<CreateAccount> _account;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        //if _accounts = null then return an new instance
        public IGenericRepository<Account> Accounts => _accounts ??= new GenericRepository<Account>(_context);

        public IGenericRepository<Transaction> Transactions => _transactions ??= new GenericRepository<Transaction>(_context);

        public IGenericRepository<User> Users => _users ??= new GenericRepository<User>(_context);

       // public IGenericRepository<CreateAccount> Account => _account ??= new GenericRepository<Account>(_context);

        //dispose is a garbage collector
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
