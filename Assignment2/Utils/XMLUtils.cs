using Assignment2.Models;
using Assignment2.Persistence;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace Assignment2.Utils
{
    internal static class XMLUtils
    {
        /// <summary>
        /// Checks if the type exists in the specified XML file
        /// </summary>
        internal static bool UserTypeExists(Type entity, string pathToXml)
        {
            var xDoc = XDocument.Load(pathToXml);
            var elem = xDoc.XPathSelectElement($"/Users/{ entity.Name }s");
            return elem != null;
        }

        /// <summary>
        /// Converts an entity to an XElement. Dynamically adds all properties using reflection.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        internal static XElement GetEntityAsXElement(User entity)
        {
            string plural = $"{entity.GetType().Name}s";
            string singular = $"{entity.GetType().Name}";

            XElement newEntity = new XElement(singular);

            List<XElement> elements = newEntity.Elements().ToList();

            // sort properties first by base class then sub class
            var properties = entity.GetType().GetProperties()
                    .Where(info => info.GetCustomAttributes(typeof(UserAttribute), true).Length > 0)
                    .OrderBy(info => info.DeclaringType != null
                                     && info.DeclaringType.IsSubclassOf(typeof(User)))
                    .ToArray();

            // iterate through properties and add to list
            int i = 0;
            foreach (var prop in properties)
            {
                elements.Insert(i++, new XElement(prop.Name, prop.GetValue(entity)));
            }

            // remove old elements and add new elements containing properties
            newEntity.Elements().Remove();
            newEntity.Add(elements);

            return newEntity;
        }

        internal static void GenerateHTML(string xmlFile, string xsltFile)
        {
            XslCompiledTransform transform = new XslCompiledTransform();
            using (XmlReader reader = XmlReader.Create(new StringReader(xsltFile)))
            {
                transform.Load(reader);
            }
            StringWriter results = new StringWriter();
            using (XmlReader reader = XmlReader.Create(new StringReader(xmlFile)))
            {
                transform.Transform(reader, null, results);
            }

             results.ToString();
            // todo result to html file
        }

        internal static int GetMaxId(string path)
        {
            int currentMax = -1;
            XElement users = XElement.Load(path);
            foreach (var userType in users.Elements())
            {
                foreach(var user in userType.Elements())
                {
                    int max = userType.Elements(userType.Name).Max(l => int.Parse(l.Element("ID").Value));
                    if (max > currentMax) currentMax = max;
                }
            }
            return currentMax;
        }
        
        internal static string GetRepoPath()
        {
            return $"{ConfigurationManager.AppSettings["Repository"]}/{typeof(User).Name}.xml";
        }

    }
}
