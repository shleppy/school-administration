using Assignment2.Models;
using Assignment2.Utils;
using System.Configuration;

namespace Assignment2.Persistence
{
    internal abstract class AbstractDBFactory
    {
        internal static AbstractDBFactory CreateDBFactory()
        {
            string dbFactory = ConfigurationManager.AppSettings["DBFactory"];
            return (AbstractDBFactory) AssemblyUtils.GetAssembly(dbFactory);
        }

        internal abstract IRepository<User> GetRepository();
    }
}
