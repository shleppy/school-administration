using Assignment2.Models;
using Assignment2.Persistence;
using Assignment2.Utils;
using Assignment2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Commands
{
    public delegate void AdminCommand(IRepository db, IAdminView view);

    public static class AdminCommands
    {
        private static IEnumerable<User> users = null;

        private static IEnumerable<User> InitiliazeUsers(IRepository db, IAdminView view)
        {
            if (users == null) 
                users = db.All<User>();
            return users;
        }
        
        public static void CreateUser(IRepository db, IAdminView view)
        {
            User user = view.ShowCreateUserView();
            db.Add(user);
        }

        public static void GetUsers(IRepository db, IAdminView view)
        {
            view.ShowUserOverview(InitiliazeUsers(db, view));
        }

        public static void GetUserById(IRepository db, IAdminView view)
        {
            Console.WriteLine();
            int id = TextProcessor.GetProperInt("Please enter the user ID: ");
            User user = InitiliazeUsers(db, view).FirstOrDefault(x => x.ID == id);
            view.ShowDetailedInfoView(user);
        }

        public static void Help(IRepository db, IAdminView view)
        {
            view.ShowMainMenu();
        }

        public static void Quit(IRepository db, IAdminView view)
        {
            view.QuitView();
        }

        public static void UnknownCommand(IRepository db, IAdminView view)
        {
            view.UnknownCommand();
        }
    }
}
