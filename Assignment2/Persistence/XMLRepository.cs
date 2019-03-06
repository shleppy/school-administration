using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Persistence
{
    public class XMLRepository : IRepository
    {
        private string _directory;

        public XMLRepository(string directory)
        {
            this.Directory = directory;
        }

        public string Directory { get => _directory; private set => _directory = value; }

        public void Add<T>(T entity) where T : IPersistableEntity
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> All<T>() where T : IPersistableEntity
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(int id) where T : IPersistableEntity
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Query<T>(Expression<Func<T, bool>> predicate) where T : IPersistableEntity
        {
            throw new NotImplementedException();
        }

        public T Single<T>(int id) where T : IPersistableEntity
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : IPersistableEntity
        {
            throw new NotImplementedException();
        }
    }
}
