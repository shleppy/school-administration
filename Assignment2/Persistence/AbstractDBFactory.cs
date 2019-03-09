using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Persistence
{
    abstract class AbstractDBFactory
    {
        static AbstractDBFactory CreateDBFactory()
        {
            string dbFactory = ConfigurationManager.AppSettings["DBFactory"];
            return (AbstractDBFactory) Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .First(x => x.Name == dbFactory)
                ?.GetConstructor(new Type[] { })
                ?.Invoke(new object[] { });
        }
    }
}
