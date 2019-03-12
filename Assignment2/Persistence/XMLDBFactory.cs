using Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Persistence
{
    internal class XMLDBFactory : AbstractDBFactory
    {
        private static AbstractDBFactory _instance = null;
        internal static AbstractDBFactory Instance 
        {
            get
            {
                if (_instance == null) 
                    _instance = new XMLDBFactory();
                return _instance;
            }
        }

        private IRepository<User> _repoLocation = null;
        internal override IRepository<User> GetRepository()
        {
            if (_repoLocation == null)
                _repoLocation = new XMLRepository(ConfigurationManager.AppSettings["Repository"]);
            return _repoLocation;
        }
    }
}
