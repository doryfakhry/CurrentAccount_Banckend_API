
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


//this is a global generic get delete update... for all objects defined once
// and the same for all projects
// Implemeted in Reporsitory folder GenericRepository class
namespace CurrentAccount.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IList<T>> GetAll(
            Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includes = null, string thenincludes = null
            );
        Task<T> Get(Expression<Func<T, bool>> expression, string includes = null, string thenincludes = null);

        Task Insert(T entity);
        Task InsertRange(IEnumerable<T> entities);
        Task Delete(int id);
        void DeleteRange(IEnumerable<T> entities);
        void update(T entity);
    }
}
