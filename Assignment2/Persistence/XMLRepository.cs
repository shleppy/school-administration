using Assignment2.Models;
using Assignment2.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Xml.Linq;
using System.Linq;

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
                Document = new XDocument(
                        new XElement("Users",
                            new XComment("All User types.")));
            }
            else
            {
                Document = XDocument.Load(Path);
            }

            Document.Save(Path);
        }

        public string Path { get; private set; }
        public XDocument Document { get; set; }

        public void Insert(User entity)
        {
            XElement xEle = XElement.Load(Path);
            string plural = $"{entity.GetType().Name}s";
            string singular = $"{entity.GetType().Name}";


            // check if user type already exists and add to correct position
            if (UserTypeExists())
            {

            }
            else
            {
                xEle.Add(new XElement(plural, new XElement(singular)));
                List<XAttribute> attributes = xEle.Attributes().ToList();

                int i = 0;
                foreach (var prop in entity.GetType().GetProperties())
                {
                    attributes.Insert(i++, new XAttribute(prop.Name, prop.GetValue(entity)));
                    //xEle.Element("Users").Add(new XElement($"{entity.GetType().Name}s", 
                      //  new XElement($"{entity.GetType().Name}",
                        //            new XAttribute(prop.GetType().Name, prop.GetValue(entity)))));
                    
                }
                xEle.Element(plural).Element(singular).Attributes().Remove();
                xEle.Element(plural).Element(singular).Add(attributes);
            }
            xEle.Save(Path);
        }

        private bool UserTypeExists()
        {
            return false;
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
