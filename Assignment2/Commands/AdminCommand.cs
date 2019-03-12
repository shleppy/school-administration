using Assignment2.Models;
using Assignment2.Persistence;
using Assignment2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Commands
{
    /// <summary>
    /// Action delegate wrapper for commands.
    /// </summary>
    internal delegate void AdminCommand(IRepository<User> db, IAdminView view);
}
