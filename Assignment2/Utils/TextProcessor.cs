using Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Utils
{
    public static class TextProcessor
    {
        private static readonly string LOGO = "\n   /$$$$$$            /$$                           /$$        /$$$$$$        /$$               /$$\n" +
                                              "  /$$__  $$          | $$                          | $$       /$$__  $$      | $$              |__/\n" +
                                              " | $$  \\__/  /$$$$$$$| $$$$$$$   /$$$$$$   /$$$$$$ | $$      | $$  \\ $$  /$$$$$$$ /$$$$$$/$$$$  /$$ /$$$$$$$\n" +
                                              " |  $$$$$$  /$$_____/| $$__  $$ /$$__  $$ /$$__  $$| $$      | $$$$$$$$ /$$__  $$| $$_  $$_  $$| $$| $$__  $$\n" +
                                              "  \\____  $$| $$      | $$  \\ $$| $$  \\ $$| $$  \\ $$| $$      | $$__  $$| $$  | $$| $$ \\ $$ \\ $$| $$| $$  \\ $$\n" +
                                              "  /$$  \\ $$| $$      | $$  | $$| $$  | $$| $$  | $$| $$      | $$  | $$| $$  | $$| $$ | $$ | $$| $$| $$  | $$\n" +
                                              " |  $$$$$$/|  $$$$$$$| $$  | $$|  $$$$$$/|  $$$$$$/| $$      | $$  | $$|  $$$$$$$| $$ | $$ | $$| $$| $$  | $$\n" +
                                              "  \\______/  \\_______/|__/  |__/ \\______/  \\______/ |__/      |__/  |__/ \\_______/|__/ |__/ |__/|__/|__/  |__/\n";



        public static readonly string WELCOME_TEXT = LOGO
            + "\n ===================================================================\n"
            + " ===                         MAIN MENU                           ===\n"
            + " ===================================================================\n"
            + "               Welcome to the administration page\n\n"
            + " We trust you have received the usual lecture from the local System\n"
            + " Administrator. It usually boils down to these three things:\n"
            + "\t #1) Respect the privacy of others.\n"
            + "\t #2) Think before you type.\n"
            + "\t #3) With great power comes great responsibility.\n\n";

        public static readonly string MAIN_MENU = "Select one of the following:\n" +
            "  [1] Create user\n" +
            "  [2] Show overview users in database\n" +
            "  [3] Show user details\n" +
            "  [h] Print this help menu\n" +
            "  [q] Exit application";

        public static readonly string UNKNOWN_COMMAND = "Unknown Command\t\t<< Error";

        public static readonly string PROMPT = "\n>>> ";
        
        public static int GetProperInt(string request)
        {
            Console.Write(request);
            int num;
            while (!int.TryParse(Console.ReadLine(), out num))
                Console.WriteLine("Incorrect Integer\t\t<< Error");
            return num;
        }
    }
}
