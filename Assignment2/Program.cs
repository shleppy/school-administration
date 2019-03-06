using Assignment2.Views;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Assignment2
{
    class Program
    {
        public static IView view;

        static void Main(string[] args)
        {
            string appType = ConfigurationManager.AppSettings["UI"];
            view = (IView)Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .First(x => x.Name == appType)
                ?.GetConstructor(new Type[] { })
                ?.Invoke(new object[] { });
            
        }




    }
}
