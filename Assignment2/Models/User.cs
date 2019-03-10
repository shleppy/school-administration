using Assignment2.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment2.Models
{
    public abstract class User : IPersistableEntity
    {
        private static int _currentUserId;

        public User(string first, string last, string nationality, string email)
        {
            ID = Interlocked.Increment(ref _currentUserId);
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
