using Assignment2.Commands;
using Assignment2.Models;
using Assignment2.Persistence;
using Assignment2.Utils;
using Assignment2.Views;
using System;
using System.Configuration;

namespace Assignment2.Controller
{
    public class Application
    {
        private readonly IRepository<User> _repository;
        private readonly IAdminView _view;

        public Application()
        {
            string appType = ConfigurationManager.AppSettings["UI"];
            _view = (IAdminView) AssemblyUtils.GetAssembly(appType);

            _repository = AbstractDBFactory.CreateDBFactory().GetRepository();
        }

        /// <summary>
        /// The main method for running the application.
        /// </summary>
        public void Run()
        {
            //bool isFirstRun = true;
            Console.CancelKeyPress += new ConsoleCancelEventHandler(ControlCHandler);
            
            _view.ShowWelcomeScreen();
            _view.ShowMainMenu();

            AdminCommand command;
            while (true)
            {
                //Console.Clear();
                //if (isFirstRun)
                //{
                //    _view.ShowWelcomeScreen();
                //    _view.ShowMainMenu();
                //    isFirstRun = false;
                //} else
                //{
                //    Console.WriteLine(TextProcessor.LOGO);
                //}

                // TODO Improve usability by clearng console every loop Console.Clear();
                if (_repository == null)
                {
                    Console.Clear();
                    Console.WriteLine("Repository is null\t\tWARNING!");
                    break;
                }
                if (_view == null)
                {
                    Console.Clear();
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

    }
}
