using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HackQuestion.Libraries.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace HackQuestion.Libraries.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly HackContext _context;
        private DbSet<T> _entity;
        private bool disposed = false;


        public Repository(HackContext context)
        {
            this._context = context;
            this._entity = context.Set<T>();

        }

        public virtual T Add(T entity)
        {
            _entity.Add(entity);
            return entity;
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            await _entity.AddAsync(entity);
            return entity;
        }
        public virtual T Delete(T entity)
        {
            _entity.Remove(entity);
            return entity;
        }
        public virtual T Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        } 

        public virtual void Save()
        {
            _context.SaveChanges();

        }
        public virtual async Task<int> SaveAsync() => await _context.SaveChangesAsync();

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual int Count() => _entity.Count();
        public virtual int Count(Expression<Func<T, bool>> where) => _entity.Where(where).Count();
        public virtual async Task<int> CountAsync() => await _entity.CountAsync();
        public virtual async Task<int> CountAsync(Expression<Func<T, bool>> where) => await _entity.Where(where).CountAsync();
        public virtual T Find(params object[] key) => _entity.Find(key);
        public virtual async Task<T> FindAsync(params object[] key) => await _entity.FindAsync(key);
        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> where)
        {
            IQueryable<T> query = _entity.Where(where);
            return query;
        }
        public virtual async Task<ICollection<T>> FindByAsync(Expression<Func<T, bool>> where) => await _entity.Where(where).ToListAsync();
        public virtual IEnumerable<T> GetAll() => _entity.ToList();
        public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>> where, int take) => _entity.Where(where).Take(take).ToList();
        
        public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>> where) => _entity.Where(where).ToList();
        public virtual async Task<IEnumerable<T>> GetAllAsync() => await _entity.ToListAsync();
        public virtual async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> where) => await _entity.Where(where).ToListAsync();
        public virtual IQueryable<T> Query() => _entity.AsNoTracking().AsQueryable();
        public virtual IQueryable<T> Query(Expression<Func<T, bool>> where) => _entity.AsNoTracking().Where(where).AsQueryable();
        public virtual async Task<T> SingleOrDefaultAsync() => await _entity.SingleOrDefaultAsync();
        public virtual async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> where) => await _entity.AsNoTracking().Where(where).SingleOrDefaultAsync();

       
    }
}