using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerDeviceShop.Util
{
    public class DialogService : IDialogService
    {
        public void MW(ICRUD crud, ICatalog catalog, IMainCategory main, IMakeOrder order, IUser user, IDialogService dialog, int id)
        {
            MainWindow mw = new MainWindow(crud, catalog, main, order, user, dialog, id);
            mw.Show();
        }
    }
}
