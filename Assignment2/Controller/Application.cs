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
        private readonly IRepository _repository;
        private readonly IAdminView _view;
        private IList<Type> _userTypes;
        
        public Application()
        {
            string appType = ConfigurationManager.AppSettings["UI"];
            _view = (IAdminView) GetAssembly(appType);

            string location = ConfigurationManager.AppSettings["Repository"];
            _repository = (IRepository) GetAssembly(location);

            _userTypes = new List<Type>();
        }

        public void Run()
        {
            InitUserTypes();
            Console.CancelKeyPress += new ConsoleCancelEventHandler(ControlCHandler);

            _view.ShowWelcomeScreen();
            _view.ShowMainMenu();

            AdminCommand command;
            while (true)
            {
                _view.ShowPrompt();
                string input = Console.ReadLine();
                command = CommandFactory.GetCommand(input);
                command.Invoke(_repository, _view);
            }
        }

        private void InitUserTypes()
        {
            var userTypeAssembly = Assembly.GetAssembly(typeof(User));
            var userTypes = userTypeAssembly.GetTypes().Where(x => x.IsSubclassOf(typeof(User)));
            foreach (Type t in userTypes)
            {
                _userTypes.Add(t);
            }
        }

        private static void ControlCHandler(object sender, ConsoleCancelEventArgs e)
        {
            Console.WriteLine(e.SpecialKey);
            if (e.SpecialKey == ConsoleSpecialKey.ControlC)
            {
                e.Cancel = true;
            }
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
