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
    public delegate void AdminCommand();

    public static class AdminCommands
    {
        private static IEnumerable<User> users = null;

        private static IEnumerable<User> GetAllUsers(IRepository db)
        {
            if (users == null) 
                users = db.All<User>();
            return users;
        }

        private static void CreateUser(IRepository db, IAdminView view)
        {
            User user = view.ShowCreateUserView();
            db.Add(user);
        }

        private static void GetUsers(IRepository db, IAdminView view)
        {
            view.ShowUserOverview(GetAllUsers(db));
        }

        private static void GetUserById(IRepository db, IAdminView view)
        {
            Console.WriteLine();
            int id = TextProcessor.GetProperInt("Please enter the user ID: ");
            User user = GetAllUsers(db).FirstOrDefault(x => x.ID == id);
            view.ShowDetailedInfoView(user);
        }
    }
}
