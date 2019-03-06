using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Persistence
{
    class XMLDBFactory : AbstractDBFactory
    {
        private static AbstractDBFactory _instance = null;
        
        public static AbstractDBFactory Instance 
        {
            get
            {
                if (_instance == null) 
                    _instance = new XMLDBFactory();
                return _instance;
            }
        }

        private IRepository _repoLocation = null;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IRepository GetRepository()
        {
            if (_repoLocation == null)
                _repoLocation = new XMLRepository(ConfigurationManager.AppSettings["Repository"]);
            return _repoLocation;
        }
    }
}
