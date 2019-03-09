using Assignment2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Persistence
{
    public class XMLRepository : IRepository<User>
    {
        private string _directory;

        public XMLRepository(string directory)
        {
            this.Dir = directory;
            Path = $"{directory}/{typeof(User).Name}.xml";
            Directory.CreateDirectory(directory);
            if (!File.Exists(Path))
            {
                new FileStream(Path, FileMode.Create).Close();
            }
        }

        public string Dir { get => _directory; private set => _directory = value; }
        public string Path { get; private set; }

        public void Add(User entity)
        {
            Console.WriteLine("Adding");
            throw new NotImplementedException();
        }

        public IEnumerable<User> All()
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Query(Expression<Func<User, bool>> predicate)
        { 
            throw new NotImplementedException();
        }

        public User Single(int id) 
        {
            throw new NotImplementedException();
        }

        public void Update(int id, User entity) 
        {
            throw new NotImplementedException();
        }
    }
}
