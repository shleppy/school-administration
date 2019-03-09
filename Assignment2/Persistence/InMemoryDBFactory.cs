using Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Persistence
{
    class InMemoryDBFactory : AbstractDBFactory
    {
        public override IRepository<User> GetRepository()
        {
            return new InMemoryRepository();
        }
    }
}
