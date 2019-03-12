using Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Assignment2.Utils
{
    internal static class AssemblyUtils
    {
        internal static object GetAssembly(string key)
        {
            return Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == key)
                ?.GetConstructor(new Type[] { })
                ?.Invoke(new object[] { });
        }

        // Private helper method to get all subclasses of User. 
        internal static IList<Type> GetUserTypes()
        {
            IList<Type> _userTypes = new List<Type>();
            var userTypes = Assembly
                .GetAssembly(typeof(User))
                .GetTypes()
                .Where(x => x.IsSubclassOf(typeof(User)));

            foreach (Type t in userTypes)
                _userTypes.Add(t);

            return _userTypes;
        }
    }
}
