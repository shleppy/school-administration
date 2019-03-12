using Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Assignment2.Persistence
{
    class InMemoryRepository : IRepository<User>
    {
        // In Memory db
        List<User> users = new List<User>();

        public void Insert(User entity)
        {
            users.Add(entity);
        }

        public IEnumerable<User> ReadAll()
        {
            return users;
        }

        public void Delete(int id)
        {
            users.Remove(users.First(x => x.ID == id));
        }

        public IEnumerable<User> Query(Expression<Func<User, bool>> predicate)
        {
            return users.Cast<User>().AsQueryable<User>().Where(predicate);
        }

        public User Read(int id)
        {
            return users.FirstOrDefault(x => x.ID == id);
        }

        public void Update(int id, User entity)
        {
            User obj = users.FirstOrDefault(x => x.ID == id);
            obj = entity;
        }
    }
}
