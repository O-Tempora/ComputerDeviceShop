using BLL.Interfaces;
using ComputerDeviceShop.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerDeviceShop.Util
{
    public class DialogService : IDialogService
    {
        public void AdmW(ICRUD crud, ICatalog catalog, IMainCategory main, IAccount account, IMakeOrder order, IUser user, IDialogService dialog, int id, IFile file)
        {
            ManagerWindow mw = new ManagerWindow(crud, catalog, main, account, order, user, dialog, id, file);
            mw.Show();
        }

        public void MW(ICRUD crud, ICatalog catalog, IMainCategory main, IAccount account, IMakeOrder order, IUser user, IDialogService dialog, int id, IFile file)
        {
            MainWindow mw = new MainWindow(crud, catalog, main, account, order, user, dialog, id, file);
            mw.Show();
        }
    }
}
