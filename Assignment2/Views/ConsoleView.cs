using Assignment2.Models;
using Assignment2.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Views
{
    class ConsoleView : IAdminView
    {
        public void ShowWelcomeScreen() { Console.WriteLine(TextProcessor.WELCOME_TEXT); }
        public void ShowMainMenu() { Console.WriteLine(TextProcessor.MAIN_MENU); }
        public void ShowPrompt() { Console.Write(TextProcessor.PROMPT); }
        public void QuitView() { Environment.Exit(0); }
        public void UnknownCommand() { Console.WriteLine(TextProcessor.UNKNOWN_COMMAND); }

        public User ShowCreateUserView(IList<Type> userTypes)
        {
            Console.WriteLine("Available user types:");
            int i = 0;
            foreach (Type type in userTypes)
                Console.WriteLine($" [{++i}] {type.Name}");
            int index = TextProcessor.GetProperInt("\nChoose the user type: ") - 1;

            var properties = userTypes
                .ElementAt(index)
                .GetProperties()
                .OrderBy(t => t.DeclaringType != null && t.DeclaringType.IsSubclassOf(typeof(User)))
                .ToArray();
            
            
            foreach(var p in properties)
            {
                Console.Write($"Please enter {p.Name}: ");
                string info = Console.ReadLine();

            }

            return null;
        }
        
        public void ShowDetailedInfoView(User user)
        {
            // TODO
        }

        public void ShowUserOverview(IEnumerable<User> users)
        {
            // TODO
        }
    }
}
