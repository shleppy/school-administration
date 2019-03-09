using Assignment2.Models;
using Assignment2.Utils;
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

        public void Insert(User entity)
        {
            var root = XMLParser.Read(Path);
            root.Add(XMLParser.Serialize(entity));
            root.Save(Path);
        }

        public void Update(int id, User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        
        public User Read(int id)
        {
            var root = XMLParser.Read(Path);
            foreach (var child in root.Nodes())
            {
                User entity = XMLParser.Deserialize(Path);
                if (entity.ID == id) return entity;
            }
            return null;
        }

        public IEnumerable<User> ReadAll()
        {
            var root = XMLParser.Read(Path);
            List<User> entities = new List<User>();
            foreach (var child in root.Nodes())
            {
                User entity = XMLParser.Deserialize(Path);
                entities.Add(entity);
            }
            return entities;
        }

        public IEnumerable<User> Query(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
