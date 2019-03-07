using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Commands
{
    public static class CommandFactory
    {
        /// <summary>
        /// Factory for admin menu commands.
        /// </summary>
        /// <param name="input">The bounded string, usually user input.</param>
        /// <returns>The corresponding command</returns>
        public static AdminCommand GetCommand(string input)
        {
            switch(input)
            {
                case "1": return AdminCommands.CreateUser;
                case "2": return AdminCommands.GetUsers;
                case "3": return AdminCommands.GetUserById;
                case "h": return AdminCommands.Help;
                case "q": return AdminCommands.Quit;
                default: return AdminCommands.UnknownCommand;
            }
        }
    }
}
