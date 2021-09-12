using Microsoft.EntityFrameworkCore;
using Mr_Black.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Mr_Black.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly ApplicationDbContext _db;
        
        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = db.Set<T>();
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            T entity = dbSet.Find(id);
            Delete(entity);
            _db.SaveChanges();
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
            _db.SaveChanges();
        }

        public void DeleteRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
            _db.SaveChanges();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null, string IncludeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);

            }

            if (IncludeProperties != null)
            {
                foreach (var item in IncludeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }

            if (orderby != null)
            {
                return orderby(query).ToList();
            }
            //.AsNoTracking()
            return query.ToList();
        }

        public T GetElement(int id)
        {
            return dbSet.Find(id);
        }
        public T GetElement(string id)
        {
            return dbSet.Find(id);
        }
        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string IncludeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);

            }

            if (IncludeProperties != null)
            {
                foreach (var item in IncludeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }

            //.AsNoTracking()
            return query.FirstOrDefault();
        }

        public void Update(T entity)
        {
            try
            {
                dbSet.Attach(entity);
                _db.Entry(entity).State = EntityState.Modified;
                _db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public void Detached(T entity)
        {
            _db.Entry<T>(entity).State = EntityState.Detached;
        }

        public void AddRange(IEnumerable<T> entity)
        {
            dbSet.AddRange(entity);
            _db.SaveChanges();
        }

        ~Repository()
        {
            _db.Dispose();

        }



    }
}
