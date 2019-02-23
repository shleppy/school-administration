using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment2.Models
{
    public enum Nationality { DUTCH, ENGLISH, GERMAN }

    public abstract class User
    {
        private static int globalId;

        public int ID { get; private set; }
        public string FirstName { get; }
        public string LastName { get; private set; }
        public string Email { get; set; }
        public Nationality Nationality { get; }
        
        public User (string firstname, string lastname, string email, Nationality nationality)
        {
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            Nationality = nationality;
            ID = Interlocked.Increment(ref globalId);
        }
    }
}
