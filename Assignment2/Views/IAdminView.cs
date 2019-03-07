using Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Views
{
    public interface IAdminView
    {
        void ShowWelcomeScreen();
        void ShowMainMenu();
        void ShowPrompt();
        void UnknownCommand();
        void QuitView();
        User ShowCreateUserView();
        void ShowDetailedInfoView(User user);
        void ShowUserOverview(IEnumerable<User> users);
    }
}
