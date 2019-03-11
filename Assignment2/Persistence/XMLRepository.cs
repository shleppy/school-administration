using Assignment2.Models;
using Assignment2.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Xml.Linq;
using System.Linq;
using System.Xml.XPath;
using System.Reflection;

namespace Assignment2.Persistence
{
    public class XMLRepository : IRepository<User>
    {
        public string Path { get; private set; }
        public XDocument Document { get; set; }

        public XMLRepository(string directory)
        {
            Directory.CreateDirectory(directory);

            Path = $"{directory}/{typeof(User).Name}.xml";
            if (!File.Exists(Path))
                Document = new XDocument(
                        new XElement("Users",
                            new XComment("All User types.")));
            else
                Document = XDocument.Load(Path);
            Document.Save(Path);
        }

        public void Insert(User entity)
        {
            XElement xEle = XElement.Load(Path);
            string pluralGroup = $"{entity.GetType().Name}s";

            // Get entity
            XElement newEntity = XMLUtils.GetEntityAsXElement(entity);

            // Create new parent if necessary
            if (XMLUtils.UserTypeExists(entity.GetType(), Path))
                xEle.Element(pluralGroup).Add(newEntity);
            else
                xEle.Add(new XElement(pluralGroup, newEntity));

            // Write to file
            xEle.Save(Path);
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
            return ReadAll().FirstOrDefault(x => x.ID == id);
        }

        public IEnumerable<User> ReadAll()
        {
            XElement xEle = XElement.Load(Path);
            IEnumerable<XElement> elements = xEle.Elements();

            var subTypes = Assembly
                .GetAssembly(typeof(User))
                .GetTypes()
                .Where(t => t.IsSubclassOf(typeof(User)))
                .ToArray();

            List<User> users = new List<User>();

            foreach(XElement element in elements)
            {
                var type = subTypes.First(subType => $"{subType.Name}s" == element.Name);
                var properties = type.GetProperties()
                    .Where(info => info.GetCustomAttributes(typeof(UserAttribute), true).Length > 0 && info.Name != "ID")
                    .OrderBy(info => info.DeclaringType != null
                                     && info.DeclaringType.IsSubclassOf(typeof(User)))
                    .ToArray();

                var userElements = element.Elements();
                foreach (var userElement in userElements)
                {
                    var propertyValues = userElement
                        .Elements()
                        .Where(x => x.Name != "ID")
                        .Select((t, i) => Convert.ChangeType(t.Value, properties[i].PropertyType))
                        .ToArray();

                    User user = (User) Activator.CreateInstance(type, propertyValues);
                    users.Add(user);
                }
            }

            return users;
        }

        public IEnumerable<User> Query(Expression<Func<User, bool>> predicate)
        {
            return ReadAll().AsQueryable().Where(predicate);
        }
    }
}
