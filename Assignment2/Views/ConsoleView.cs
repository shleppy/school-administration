using Assignment2.Models;
using Assignment2.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Xsl;

namespace Assignment2.Views
{
    class ConsoleView : IAdminView
    {
        public void ShowWelcomeScreen() { Console.WriteLine(TextProcessor.WELCOME_TEXT); }
        public void ShowMainMenu() { Console.WriteLine(TextProcessor.MAIN_MENU); }
        public void ShowPrompt() { Console.Write(TextProcessor.PROMPT); }
        public void UnknownCommand() { Console.WriteLine(TextProcessor.UNKNOWN_COMMAND); }
        public void ShowGenerateHTMLView() { Console.WriteLine("Still being implemented."); }

        public void ShowDetailedInfoView(User user)
        {
            if (user == null)
            {
                Console.WriteLine("No user found.");
                return;
            }

            var properties = user.GetType().GetProperties()
                .Where(p => p.Name != "ID")
                .OrderBy(t => t.DeclaringType != null && t.DeclaringType.IsSubclassOf(typeof(User)))
                .ToArray();

            Console.WriteLine($"{user.GetType().Name} [{user.ID}]:");
            foreach (var prop in properties)
            {
                Console.WriteLine($"  {prop.Name, -22}: {prop.GetValue(user)}");
            }
        }

        public void ShowUserOverview(IEnumerable<User> users)
        {
            if (users.Count() == 0)
            {
                Console.WriteLine("No users in database.");
                return;
            }

            int idPadding = users.Max(x => x.ID.ToString().Length) + 2;
            int firstPadding = users.Max(x => x.FirstName.ToString().Length) + 3;
            int lastPadding = users.Max(x => x.LastName.ToString().Length) + 1;
            int typePadding = users.Max(x => x.GetType().Name.ToString().Length) + 1;

            if (idPadding < 3) idPadding = 3;
            if (firstPadding < 10) firstPadding = 10;
            if (lastPadding < 9) lastPadding = 9;
            if (typePadding < 5) typePadding = 5;

            Console.WriteLine($"| {"ID".PadRight(idPadding)} | " +
              $"{"First Name".PadRight(firstPadding)} | " +
              $"{"Last Name".PadRight(lastPadding)} | " +
              $"{"Type".PadRight(typePadding)} | ");

            Console.WriteLine($"|-{"-".PadRight(idPadding, '-')}-" +
                $"|-{"-".PadRight(firstPadding, '-')}-" +
                $"|-{"-".PadRight(lastPadding, '-')}-" +
                $"|-{"-".PadRight(typePadding, '-')}-|");

            foreach (User user in users)
            {
                Console.WriteLine($"| {user.ID.ToString().PadRight(idPadding)} | " +
                    $"{user.FirstName.PadRight(firstPadding)} | " +
                    $"{user.LastName.PadRight(lastPadding)} | " +
                    $"{user.GetType().Name.PadRight(typePadding)} |");
            }
        }

        public void QuitView()
        {
            var isConfirmed = TextProcessor.GetConfirmation(" Are you sure you want to exit? (y/N): ");
            if (isConfirmed)
                Environment.Exit(0);
        }


        public User ShowAndCreateUserView()
        {
            // Get user type from input
            Console.WriteLine("Available user types:");
            var type = GetUserType();

            // Get property info of that type
            var propertyInfo = GetRemainingPropInfo(type);

            // Call constructor of the type using reflection
            User user = (User)Activator.CreateInstance(type, propertyInfo);

            Console.WriteLine($"\nCreated new {user.GetType().Name}");
            return user;
        }

        private Type GetUserType()
        {
            var userTypes = AssemblyUtils.GetUserTypes();

            int i = 0;
            foreach (Type t in userTypes)
                Console.WriteLine($"  [{++i}] {t.Name}");
            int index = TextProcessor.GetProperInt("\n Choose the user type: ") - 1;
            return userTypes.ElementAt(index);
        }

        private object[] GetRemainingPropInfo(Type type)
        {
            var properties = type.GetProperties()
                .Where(p => p.Name != "ID")
                .OrderBy(t => t.DeclaringType != null && t.DeclaringType.IsSubclassOf(typeof(User)))
                .ToArray();

            var propertyInfo = new object[properties.Length];
            int j = 0;
            foreach (var p in properties)
            {
                if (p.Name == "StartingDate")
                {
                    DateTime info = TextProcessor.GetProperDateTime($" Please enter {p.Name}: ");
                    propertyInfo[j++] = info;
                }
                else if (p.Name.Contains("EmailAddress"))
                {
                    string info = TextProcessor.GetProperEmail($" Please enter {p.Name}: ");
                    propertyInfo[j++] = info;
                }
                else
                {
                    Console.Write($" Please enter {p.Name}: ");
                    string info = Console.ReadLine();
                    propertyInfo[j++] = info;
                }
            }
            return propertyInfo;
        }
    }
}
