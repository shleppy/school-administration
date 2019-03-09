using Assignment2.Models;
using Assignment2.Persistence;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Assignment2.Utils
{
    public static class XMLParser
    {
        public static void Write(User entity, string path)
        {
            XmlSerializer writer = new XmlSerializer(typeof(User));
            FileStream file = File.Open(path, FileMode.OpenOrCreate);
            writer.Serialize(file, entity);
            file.Close();
        }

        public static XElement Read(string path)
        {
            XmlSerializer reader = new XmlSerializer(typeof(User));
            StreamReader file = new StreamReader(path);
            XElement root = XElement.Load(path);
            return root;
        }

        public static XElement Serialize(User entity)
        {
            var properties = typeof(User).GetProperties()
                .Where(x => Attribute.IsDefined(x, typeof(UserAttribute)));

            XmlSerializer serializer = new XmlSerializer(typeof(User));
            XElement child = new XElement(typeof(User).Name);
            using (var stream = new MemoryStream())
            {
                serializer.Serialize(stream, entity);
                stream.Position = 0;

                using (XmlReader reader = XmlReader.Create(stream))
                {
                    XElement element = XElement.Load(reader);
                    return element;
                }
            }
        }

        public static User Deserialize(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(XElement));
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.Serialize(ms, path);
                ms.Position = 0;

                serializer = new XmlSerializer(typeof(User));
                object obj = serializer.Deserialize(ms);
                return (User) obj;
            }
        }
    }
}
