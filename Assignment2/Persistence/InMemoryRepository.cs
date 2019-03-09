using Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Persistence
{
    class InMemoryRepository : IRepository
    {
        IList<IPersistableEntity> users = new List<IPersistableEntity>();

        public void Add<T>(T entity) where T : IPersistableEntity
        {
            users.Add(entity);
        }

        public IEnumerable<T> All<T>() where T : IPersistableEntity
        {
            return (IEnumerable<T>) users;
        }

        public void Delete<T>(int id) where T : IPersistableEntity
        {
            users.Remove(users.First(x => x.ID == id));
        }

        public IEnumerable<T> Query<T>(Expression<Func<T, bool>> predicate) where T : IPersistableEntity
        {
            return users.Cast<T>().AsQueryable<T>().Where(predicate);
        }

        public T Single<T>(int id) where T : IPersistableEntity
        {
            return (T) users.FirstOrDefault(x => x.ID == id);
        }

        public void Update<T>(int id, T entity) where T : IPersistableEntity
        {
            T obj = (T) users.FirstOrDefault(x => x.ID == id);
            obj = entity;
        }
    }
}
