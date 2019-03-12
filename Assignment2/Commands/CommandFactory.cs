namespace Assignment2.Commands
{
    internal static class CommandFactory
    {
        /// <summary>
        /// Factory for admin menu commands.
        /// </summary>
        /// <param name="input">The bounded string, usually user input.</param>
        /// <returns>The corresponding command</returns>
        internal static AdminCommand GetCommand(string input)
        {
            switch(input)
            {
                case "1": return AdminCommands.CreateUser;
                case "2": return AdminCommands.GetUsers;
                case "3": return AdminCommands.GetUserById;
                case "4": return AdminCommands.GenerateHtml;
                case "h": return AdminCommands.Help;
                case "q": return AdminCommands.Quit;
                default: return AdminCommands.UnknownCommand;
            }
        }
    }
}
