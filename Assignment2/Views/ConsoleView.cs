using Assignment2.Models;
using Assignment2.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Views
{
    class ConsoleView : IAdminView
    {
        public void ShowWelcomeScreen()
        {
            Console.WriteLine(TextProcessor.WELCOME_TEXT);
        }

        public void ShowMainMenu()
        {
            Console.WriteLine(TextProcessor.MAIN_MENU);
        }

        public User ShowCreateUserView()
        {
             // TODO
            return null;
        }

        public void ShowDetailedInfoView(User user)
        {
            throw new NotImplementedException();
        }

        public void ShowUserOverview(IEnumerable<User> users)
        {
            throw new NotImplementedException();
        }
    }
}
