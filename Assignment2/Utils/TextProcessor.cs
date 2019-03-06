using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Utils
{
    public static class TextProcessor
    {
        private static readonly string LOGO = "";
        public static readonly string WELCOME_TEXT = LOGO + "";
        public static readonly string MAIN_MENU = "";
        
        public static int GetProperInt(string request)
        {
            Console.Write(request + "\n");
            int num;
            while (int.TryParse(Console.ReadLine(), out num))
                Console.WriteLine("Incorrect Integer\t\t<< Error");
            return num;
        }

        
    }
}
