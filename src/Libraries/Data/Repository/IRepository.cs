using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HackQuestion.Libraries.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);
        Task<T> AddAsync(T entity);


        T Delete(T entity);
        T Update (T entity);
        Task<int> SaveAsync();
        
        void Save();


        void Dispose();

        Task<T> SingleOrDefaultAsync();
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> where);

        int Count();
        int Count(Expression<Func<T, bool>> where);
        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<T, bool>> where);

        T Find(params object[] key);
        Task<T> FindAsync(params object[] key);


        IQueryable<T> FindBy(Expression<Func<T, bool>> where);
        Task<ICollection<T>> FindByAsync(Expression<Func<T, bool>> where);


        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T, bool>> where);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> where, int take);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> where);

        IQueryable<T> Query();
        IQueryable<T> Query(Expression<Func<T, bool>> where);


    }
}