using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;

namespace ComputerDeviceShop.Util
{
    public interface IDialogService
    {
        void MW(ICRUD crud, ICatalog catalog, IMainCategory main, IAccount account, IMakeOrder order, IUser user, IDialogService dialog, int id, IFile file);
        void AdmW(ICRUD crud, ICatalog catalog, IMainCategory main, IAccount account, IMakeOrder order, IUser user, IDialogService dialog, int id, IFile file);
    }
}
