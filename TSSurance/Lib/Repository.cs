using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TSSurance.Models;

namespace TSSurance.Lib
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private TSureDbContext _db;
        protected DbSet<T> _dbSet;
        private void SaveChanges()
        {
            _db.SaveChanges();
        }
        public Repository(TSureDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }
        public void Create(T entity)
        {
            //throw new NotImplementedException();
            _dbSet.Add(entity);
            SaveChanges();
        }

        public void Delete(int id)
        {
            _dbSet.Remove(_dbSet.Find(id));
            SaveChanges();
        }

        public T Get(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}