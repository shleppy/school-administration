using Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Assignment2.Utils
{
    internal static class TextProcessor
    {
        internal static readonly string LOGO = "\n   /$$$$$$            /$$                           /$$        /$$$$$$        /$$               /$$\n" +
                                              "  /$$__  $$          | $$                          | $$       /$$__  $$      | $$              |__/\n" +
                                              " | $$  \\__/  /$$$$$$$| $$$$$$$   /$$$$$$   /$$$$$$ | $$      | $$  \\ $$  /$$$$$$$ /$$$$$$/$$$$  /$$ /$$$$$$$\n" +
                                              " |  $$$$$$  /$$_____/| $$__  $$ /$$__  $$ /$$__  $$| $$      | $$$$$$$$ /$$__  $$| $$_  $$_  $$| $$| $$__  $$\n" +
                                              "  \\____  $$| $$      | $$  \\ $$| $$  \\ $$| $$  \\ $$| $$      | $$__  $$| $$  | $$| $$ \\ $$ \\ $$| $$| $$  \\ $$\n" +
                                              "  /$$  \\ $$| $$      | $$  | $$| $$  | $$| $$  | $$| $$      | $$  | $$| $$  | $$| $$ | $$ | $$| $$| $$  | $$\n" +
                                              " |  $$$$$$/|  $$$$$$$| $$  | $$|  $$$$$$/|  $$$$$$/| $$      | $$  | $$|  $$$$$$$| $$ | $$ | $$| $$| $$  | $$\n" +
                                              "  \\______/  \\_______/|__/  |__/ \\______/  \\______/ |__/      |__/  |__/ \\_______/|__/ |__/ |__/|__/|__/  |__/\n";



        internal static readonly string WELCOME_TEXT = LOGO
            + "\n ===================================================================\n"
            + " ===                         MAIN MENU                           ===\n"
            + " ===================================================================\n"
            + "               Welcome to the administration page\n\n"
            + " We trust you have received the usual lecture from the local System\n"
            + " Administrator. It usually boils down to these three things:\n"
            + "\t #1) Respect the privacy of others.\n"
            + "\t #2) Think before you type.\n"
            + "\t #3) With great power comes great responsibility.\n";



        internal static readonly string MAIN_MENU = "Select one of the following:\n" +
            "  [1] Create user\n" +
            "  [2] Show overview users in database\n" +
            "  [3] Show user details\n" +
            "  [4] Generate HTML file\n" +
            "  [h] Print this help menu\n" +
            "  [q] Exit application";

        internal static readonly string UNKNOWN_COMMAND = "Unknown Command\t\t<< Error";

        internal static readonly string PROMPT = "\n>>> ";
        
        internal static int GetProperInt(string request)
        {
            Console.Write(request);
            int num;
            while (!int.TryParse(Console.ReadLine(), out num))
                Console.WriteLine("Invalid Integer\t\t<< Error");
            return num;
        }

        internal static bool GetConfirmation(string request)
        {
            Console.Write(request);
            string input = Console.ReadLine();
            return (input == "y" || input == "yes");
        }

        internal static DateTime GetProperDateTime(string request)
        {
            var dateFormats = new[] { "MM.dd.yyyy", "MM-dd-yyyy", "MM/dd/yyyy", "MM dd yyyy",
                                      "dd.MM.yyyy", "dd-MM-yyyy", "dd/MM/yyyy", "dd MM yyyy"};
            DateTime resultDate;
            bool validDate = false;
            do
            {
                Console.Write(request);
                string input = Console.ReadLine();

                if (DateTime.TryParseExact(input, dateFormats, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, out resultDate))
                    validDate = true;
                else
                    Console.WriteLine("Invalid date\t\t<< Error");

            } while (!validDate);

            return resultDate;
        }

        internal static string GetProperEmail(string request)
        {
            // 1 - n characters | @ | 1 - n |. | 1 -n characters | minimal example: a@b.c
            Regex _emailRegex = new Regex(".+@.+\\..+");

            bool isValidEmail = false;
            string input = "";
            while (!isValidEmail)
            {
                Console.Write(request);

                input = Console.ReadLine();

                if (_emailRegex.IsMatch(input))
                    isValidEmail = true;
                else
                    Console.WriteLine("Invalid email\t\t<< Error");
            }
            return input;
        }
    }
}
