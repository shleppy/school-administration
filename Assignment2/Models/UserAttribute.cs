using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Models
{
    /// <summary>
    /// Attribute of the superclass User.
    /// </summary>
    class UserAttribute : Attribute
    {
        string AttributeName { get; } 

        public UserAttribute(string description)
        {
            this.AttributeName = description;
        }
    }
}
