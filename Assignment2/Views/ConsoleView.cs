﻿using Assignment2.Models;
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
            Console.WriteLine(" Are you sure you want to exit? (y/N): ");
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
                Console.WriteLine($"  [{++i}] {t.Name}");
            int index = TextProcessor.GetProperInt("\n Choose the user type: ") - 1;
            
            var type = userTypes.ElementAt(index);
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
                    DateTime info = DateTime.Now;
                    propertyInfo[j++] = info;
                    Console.WriteLine($" Starting time set to: {info}");
                    continue;
                }
                else
                {
                    Console.Write($" Please enter {p.Name}: ");
                    string info = Console.ReadLine();
                    propertyInfo[j++] = info;
                }
            }

            User user = (User) Activator.CreateInstance(type, propertyInfo);

            Console.WriteLine($"\nCreated new {user.GetType().Name}");
            return user;
        }
        
        public void ShowDetailedInfoView(User user)
        {
            // TODO
            if (user == null)
            {
                Console.WriteLine("No user found.");
                return;
            }

            var properties = user.GetType().GetProperties();
            Console.WriteLine($"{user.GetType().Name} [{user.ID}]:");
            foreach (var prop in properties)
            {
                Console.WriteLine($"  {prop.Name}: {prop.GetValue(user)}");
            }
            
        }

        public void ShowUserOverview(IEnumerable<User> users)
        {
            // TODO
            if (users.Count() == 0)
            {
                Console.WriteLine("No users in database.");
                return;
            }
            foreach (User user in users)
            {
                var properties = user.GetType().GetProperties();
                Console.WriteLine($"{user.GetType().Name} [{user.ID}]:");
                foreach (var prop in properties)
                {
                    Console.WriteLine($"  {prop.Name}: {prop.GetValue(user)}");
                }
            }
        }
    }
}
