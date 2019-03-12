using Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Views
{
    internal interface IAdminView
    {
        /// <summary>
        /// Shows the welcome screen.
        /// </summary>
        void ShowWelcomeScreen();
        /// <summary>
        /// Shows the main menu.
        /// </summary>
        void ShowMainMenu();
        /// <summary>
        /// Optional. Shows prompt (used in CLI applications).
        /// </summary>
        void ShowPrompt();
        /// <summary>
        /// Shows a view for handling unknown commands.
        /// </summary>
        void UnknownCommand();
        /// <summary>
        /// Quits the application and handles necessary prerequisites before quittng.
        /// </summary>
        void QuitView();
        /// <summary>
        /// Shows the view for creating a new user and returns the result.
        /// </summary>
        /// <param name="userTypes">A list of possible user types. 
        /// You will likely want to have this created dynamically.</param>
        /// <returns>A newly created instance of the base type User.</returns>
        User ShowAndCreateUserView();
        /// <summary>
        /// Shows the view containing detailed information about a single user
        /// </summary>
        /// <param name="user">The user to be shown.</param>
        void ShowDetailedInfoView(User user);
        /// <summary>
        /// Shows the view containing all the users and their most important information.
        /// </summary>
        /// <param name="users">The list of users to be shown.</param>
        void ShowUserOverview(IEnumerable<User> users);
        /// <summary>
        /// 
        /// </summary>
        void ShowGenerateHTMLView();

    }
}
