using Assignment2.Models;
using Assignment2.Persistence;
using Assignment2.Utils;
using Assignment2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Assignment2.Commands
{
    internal static class AdminCommands
    {
        private static IEnumerable<User> _users;

        /// <summary>
        /// Starts A view for creating a new user and adds the result to the database.
        /// </summary>
        /// <param name="db">The location of the database.</param>
        /// <param name="view">The view which should be shown to the client.</param>
        internal static void CreateUser(IRepository<User> db, IAdminView view)
        {
            User user = view.ShowAndCreateUserView();
            InitUsers(db, view);
            if (user != null)
            {
                user.ID = (_users.Count() > 0) ? _users.Max(x => x.ID) + 1 : 1;
                db.Insert(user);
            }
        }

        /// <summary>
        /// Starts a view to show all the user in the database.
        /// </summary>
        /// <param name="db">The location of the database containing all the users</param>
        /// <param name="view">The view on which the users should be shown.</param>
        internal static void GetUsers(IRepository<User> db, IAdminView view)
        {
            InitUsers(db, view);
            view.ShowUserOverview(_users);
        }

        private static void InitUsers(IRepository<User> db , IAdminView view)
        {
            _users = db.ReadAll();
        }

        /// <summary>
        /// Stars a view showing detailed information about a single user.
        /// </summary>
        /// <param name="db">The location of the database containing all the users.</param>
        /// <param name="view">The view on which the detailed user information should be shown.s</param>
        internal static void GetUserById(IRepository<User> db, IAdminView view)
        {
            int id = TextProcessor.GetProperInt("Please enter the user ID: ");
            User user = db.Read(id);
            view.ShowDetailedInfoView(user);
        }

        /// <summary>
        /// Starts a view showing a help menu (or possible commands).
        /// </summary>
        /// <param name="db">Optional location of database in case extra information needs to be shown.</param>
        /// <param name="view">The view on which the help information should be shown.</param>
        internal static void Help(IRepository<User> db, IAdminView view)
        {
            view.ShowMainMenu();
        }

        /// <summary>
        /// Starts the quit command of the application which should be called on a view to close the application.
        /// </summary>
        /// <param name="db">Optional location of database in case extra handling is required. 
        /// (e.g. persisting changes before quitting)</param>
        /// <param name="view">The view on which the quit command is called.</param>
        internal static void Quit(IRepository<User> db, IAdminView view)
        {
            view.QuitView();
        }

        /// <summary>
        /// Starts an optional view which handles any cases of improper commands.
        /// </summary>
        /// <param name="db">Location of optional database, probably not necessary in this context, but future proof.</param>
        /// <param name="view">The view on which handles the unknown command.</param>
        internal static void UnknownCommand(IRepository<User> db, IAdminView view)
        {
            view.UnknownCommand();
        }

        internal static void GenerateHtml(IRepository<User> db, IAdminView view)
        {
            // TODO Generate html file using XSLT ( generate table containing all users in html )
            view.ShowGenerateHTMLView();
        }
    }
}
