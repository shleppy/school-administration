using System;

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
