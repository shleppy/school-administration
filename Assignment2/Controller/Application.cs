using Assignment2.Commands;
using Assignment2.Models;
using Assignment2.Persistence;
using Assignment2.Utils;
using Assignment2.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Controller
{
    public class Application
    {
        private readonly IRepository<User> _repository;
        private readonly IAdminView _view;

        public Application()
        {
            string appType = ConfigurationManager.AppSettings["UI"];
            _view = (IAdminView) GetAssembly(appType);

            _repository = AbstractDBFactory.CreateDBFactory().GetRepository();
        }

        /// <summary>
        /// The main method for running the application.
        /// </summary>
        public void Run()
        {
            Console.CancelKeyPress += new ConsoleCancelEventHandler(ControlCHandler);
            
            _view.ShowWelcomeScreen();
            _view.ShowMainMenu();

            AdminCommand command;
            while (true)
            {
                if (_repository == null)
                {
                    Console.WriteLine("Repository is null\t\tWARNING!");
                    break;
                }
                if (_view == null)
                {
                    Console.WriteLine("View is null\t\tWARNING!");
                    break;
                }
                _view.ShowPrompt();
                string input = Console.ReadLine();
                command = CommandFactory.GetCommand(input);
                command.Invoke(_repository, _view);
            }
        }

        private static void ControlCHandler(object sender, ConsoleCancelEventArgs e)
        {
            if (e.SpecialKey == ConsoleSpecialKey.ControlC)
                e.Cancel = true;
        }

        private object GetAssembly(string key)
        {
            return Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == key)
                ?.GetConstructor(new Type[] { })
                ?.Invoke(new object[] { });
        }
    }
}
