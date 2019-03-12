using Assignment2.Models;

namespace Assignment2.Persistence
{
    class InMemoryDBFactory : AbstractDBFactory
    {
        internal override IRepository<User> GetRepository()
        {
            return new InMemoryRepository();
        }
    }
}
