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
    public enum Nationality { DUTCH, ENGLISH, GERMAN, OTHER }

    public abstract class User : IPersistableEntity
    {
        private static int _currentUserId;
        private static readonly Regex _emailRegex = new Regex("");

        private string emailAddress;

        public User()
        {
            ID = Interlocked.Increment(ref _currentUserId);
        }

        [UserAttribute("id")]
        public int ID { get; set; }
        [UserAttribute("first_name")]
        public string FirstName { get; set; }
        [UserAttribute("last_name")]
        public string LastName { get; set; }
        [UserAttribute("nationality")]
        public Nationality Nationality { get; set; }
        [UserAttribute("email")]
        public string EmailAddress
        {
            get => this.emailAddress;
            set
            {
                if (_emailRegex.IsMatch(value))
                    throw new ArgumentException("Invalid email found.");
                else
                    this.emailAddress = value;
            }
        }
    }
}
