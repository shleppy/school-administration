using Assignment2.Models;
using Assignment2.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Xml;
using System.Xml.Linq;

namespace Assignment2.Persistence
{
    public class XMLRepository : IRepository<User>
    {
        public XMLRepository(string directory)
        {
            Path = $"{directory}/{typeof(User).Name}.xml";
            Directory.CreateDirectory(directory);

            if (!File.Exists(Path))
            {
                using (FileStream fs = File.Create(Path))
                {
                    
                    fs.Close();
                }
                File.WriteAllText(Path, "<data></data>");
                Document = new XDocument(new XElement("administration", new XElement("users")));
                Document.Save(Path);
            }
            else
            {
                Document = XDocument.Load(Path);
                using (FileStream fs = File.Open(Path, FileMode.Open)) 
                {
                    Document.Save(Path);
                    fs.Close();
                }
            }
        }

        public string Path { get; private set; }
        public XDocument Document { get; set; }

        public void Insert(User entity)
        {
            XElement root = XElement.Load(Path);
            
            foreach (var prop in entity.GetType().GetProperties())
            {
                root.Add("users", new XElement($"{entity.GetType().Name}",
                    new XAttribute(prop.GetType().Name, prop.GetValue(entity))));
            }
            using (FileStream fs = File.Open(Path, FileMode.Open))
            {
                Document.Save(Path);
                fs.Close();
            }
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
                User entity = null; //XMLParser.Deserialize(Path);
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
                User entity = null; // XMLParser.Deserialize(Path);
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
