using CurrentAccount.IRepository;
using CurrentAccount.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace CurrentAccount.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        //dependancy  injection I can get  DatabaseContext  and DbSet object here
        private readonly AppDbContext _context;
        private readonly DbSet<T> _db;

        //depnedancy injection require me to create a constructor
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }
        public async Task Delete(int id)
        {
            var entity = await _db.FindAsync(id);
            _db.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _db.RemoveRange(entities);
        }

        
        public async Task<T> Get(Expression<Func<T, bool>> expression, string includes = null, string thenincludes = null)
        
        {            
            IQueryable<T> query = _db;

            if (includes != null)
            {
                  query = query.Include(includes);                    
            }

            if (thenincludes != null)
            {
                    query = query.Include(thenincludes);
            }
            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includes = null, string thenincludes = null)
        {
            IQueryable<T> query = _db;
            if (expression != null)
            {
                query = query.Where(expression);
            }
            if (includes != null)
            {
                
                    query = query.Include(includes);
                
            }
            if (thenincludes != null)
            {
                query = query.Include(thenincludes);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }
            return await query.AsNoTracking().ToListAsync();
        }

        public async Task Insert(T entity)
        {
            await _db.AddAsync(entity);
        }

        public async Task InsertRange(IEnumerable<T> entities)
        {
            await _db.AddRangeAsync(entities);
        }

        public void update(T entity)
        {
            _db.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;


        }
    }
}
