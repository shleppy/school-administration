using Assignment2.Models;
using Assignment2.Persistence;
using Assignment2.Utils;
using Assignment2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Commands
{
    public delegate void AdminCommand(IRepository<User> db, IAdminView view);

    public static class AdminCommands
    {
        private static IEnumerable<User> users = null;

        /// <summary>
        /// Starts A view for creating a new user and adds the result to the database.
        /// </summary>
        /// <param name="db">The location of the database.</param>
        /// <param name="view">The view which should be shown to the client.</param>
        public static void CreateUser(IRepository<User> db, IAdminView view)
        {
            User user = view.ShowCreateUserView(GetUserTypes());
            if (user != null)
                db.Insert(user);
            InitiliazeUsers(db, true);        // init to prevent null reference
        }

        /// <summary>
        /// Starts a view to show all the user in the database.
        /// </summary>
        /// <param name="db">The location of the database containing all the users</param>
        /// <param name="view">The view on which the users should be shown.</param>
        public static void GetUsers(IRepository<User> db, IAdminView view)
        {
            view.ShowUserOverview(InitiliazeUsers(db, false));
        }

        /// <summary>
        /// Stars a view showing detailed information about a single user.
        /// </summary>
        /// <param name="db">The location of the database containing all the users.</param>
        /// <param name="view">The view on which the detailed user information should be shown.s</param>
        public static void GetUserById(IRepository<User> db, IAdminView view)
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
        public static void Help(IRepository<User> db, IAdminView view)
        {
            view.ShowMainMenu();
        }

        /// <summary>
        /// Starts the quit command of the application which should be called on a view to close the application.
        /// </summary>
        /// <param name="db">Optional location of database in case extra handling is required. 
        /// (e.g. persisting changes before quitting)</param>
        /// <param name="view">The view on which the quit command is called.</param>
        public static void Quit(IRepository<User> db, IAdminView view)
        {
            view.QuitView();
        }

        /// <summary>
        /// Starts an optional view which handles any cases of improper commands.
        /// </summary>
        /// <param name="db">Location of optional database, probably not necessary in this context, but future proof.</param>
        /// <param name="view">The view on which handles the unknown command.</param>
        public static void UnknownCommand(IRepository<User> db, IAdminView view)
        {
            view.UnknownCommand();
        }

        public static void GenerateHtml(IRepository<User> db, IAdminView view)
        {
            // TODO Generate html file using XSLT ( generate table containing all users in html )
            Console.WriteLine("Not yet implemented.");
        }

        // Private helper method lazy initialization of user list
        private static IEnumerable<User> InitiliazeUsers(IRepository<User> db, bool forceUpdate)
        {
            if (users == null || forceUpdate)
                users = db.ReadAll();
            return users;
        }

        // Private helper method to get all subclasses of User. 
        private static IList<Type> GetUserTypes()
        {
            IList<Type> _userTypes = new List<Type>();
            var userTypeAssembly = Assembly.GetAssembly(typeof(User));
            var userTypes = userTypeAssembly.GetTypes().Where(x => x.IsSubclassOf(typeof(User)));

            foreach (Type t in userTypes)
                _userTypes.Add(t);

            return _userTypes;
        }
    }
}
