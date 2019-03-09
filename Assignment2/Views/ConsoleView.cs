using Assignment2.Models;
using Assignment2.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Views
{
    class ConsoleView : IAdminView
    {
        public void ShowWelcomeScreen() { Console.WriteLine(TextProcessor.WELCOME_TEXT); }
        public void ShowMainMenu() { Console.WriteLine(TextProcessor.MAIN_MENU); }
        public void ShowPrompt() { Console.Write(TextProcessor.PROMPT); }
        public void UnknownCommand() { Console.WriteLine(TextProcessor.UNKNOWN_COMMAND); }
        public void QuitView()
        {
            Console.WriteLine("Are you sure you want to exit? (y/N): ");
            string input = Console.ReadLine();
            if (input == "y")
            {
                Console.WriteLine("Exiting...");
                Environment.Exit(0);
            }
        }

        public User ShowCreateUserView(IList<Type> userTypes)
        {
            Console.WriteLine("Available user types:");
            int i = 0;
            foreach (Type t in userTypes)
                Console.WriteLine($" [{++i}] {t.Name}");
            int index = TextProcessor.GetProperInt("\nChoose the user type: ") - 1;
            
            var type = userTypes.ElementAt(index);
            var properties = type.GetProperties()
                .OrderBy(t => t.DeclaringType != null && t.DeclaringType.IsSubclassOf(typeof(User)))
                .ToArray();

            IList<string> propertyInfo = new List<string>();
            foreach (var p in properties)
            {
                if (p.Name != "ID")
                {
                    Console.Write($"Please enter {p.Name}: ");
                    string info = Console.ReadLine();
                    propertyInfo.Add(info);
                }
            }
            
            // TODO create a new user with the information
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
