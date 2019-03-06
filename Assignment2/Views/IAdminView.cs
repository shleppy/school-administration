using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Views
{
    public interface IAdminView
    {
        void ShowCreateUserView();
        void ShowDetailedInfoView(int id);
        void ShowUserOverview();
    }
}
