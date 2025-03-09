using Data.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Data.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        Context db = new Context();
        DbSet<T> _object;

        public GenericRepository()
        {
            _object = db.Set<T>();
        }

        public void Delete(T p)
        {
            var deletedEntity = db.Entry(p);
            deletedEntity.State = EntityState.Deleted;
            db.SaveChanges();
        }

        public T GetById(int id)
        {
            return _object.Find(id);
        }

        public void Insert(T p)
        {
            var addedEntity = db.Entry(p);
            addedEntity.State = EntityState.Added;
            db.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T p)
        {
            var updatedEntity = db.Entry(p);
            updatedEntity.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}