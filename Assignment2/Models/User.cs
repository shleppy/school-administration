using Assignment2.Persistence;
using System.Threading;

namespace Assignment2.Models
{
    public abstract class User : IPersistableEntity
    {
        private static int _currentUserId;

        public User()
        {
            ID = _currentUserId++;
        }

        public User(string first, string last, string nationality, string email) : this()
        {
            FirstName = first;
            LastName = last;
            Nationality = nationality;
            EmailAddress = email;
        }

        public User(int id, string first, string last, string nationality, string email)
        {
            if (_currentUserId <= id)
                _currentUserId = id + 1;

            ID = id;
            // ID = Interlocked.Increment(ref _currentUserId);
            FirstName = first;
            LastName = last;
            Nationality = nationality;
            EmailAddress = email;
        }

        [UserAttribute("id")]
        public int ID { get; set; }
        [UserAttribute("First Name")]
        public string FirstName { get; set; }
        [UserAttribute("Last Name")]
        public string LastName { get; set; }
        [UserAttribute("Nationality")]
        public string Nationality { get; set; }
        [UserAttribute("Email Address")]
        public string EmailAddress { get; set; }
    }
}
